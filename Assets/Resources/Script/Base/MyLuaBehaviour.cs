using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;
namespace MyExamp
{
    [System.Serializable]//1.方便存硬盘2.方便传输3.类的所有属性编辑界面显示
    public class Injection
    {
        public string name;
        public GameObject value;
    }
    //打了标签，lua就可以访问类的所有属性及方法
    [LuaCallCSharp]//教程说如果不打，就用性能较低的方式访问
    public class MyLuaBehaviour : MonoBehaviour
    {
        public TextAsset luaScript;
        public Injection[] injections;

       // internal static LuaEnv luaEnv = new LuaEnv();
        internal static float lastGCTime = 0;
        internal static float GCInterval = 1;//1 scond

        private Action luaStart;
        private Action luaUpdate;
        private Action luaOnDestroy;

        private LuaTable scriptEnv;

        private void Awake()
        {
            scriptEnv =  GameCtrl.luaEnv.NewTable();
            //为每个脚本设立一个独立的环境，防止污染变量
            LuaTable meta = GameCtrl.luaEnv.NewTable();
            meta.Set("__index", GameCtrl.luaEnv.Global);
            scriptEnv.SetMetaTable(meta);
            meta.Dispose();

            scriptEnv.Set("self", this);
            if(injections != null)
            {
                foreach (var injection in injections)//设置lua变量值
                {
                    scriptEnv.Set(injection.name, injection.value);
                }
            }
           
           
            if(luaScript != null)
            {
                LoardLuaScript(luaScript.text);
            }
        }

        public void InitLuaScript()
        {

            string scriptName = "";
            if (Protocol.ScriptName.ContainsKey(gameObject.name))  
            {
                scriptName = Protocol.ScriptName[gameObject.name];
            }
            else
            {
                scriptName = string.Format("Script/UI/{0}.lua", gameObject.name);
            }
            luaScript = Resources.Load<TextAsset>(scriptName);
            LoardLuaScript(luaScript.text);
        }
        public void LoardLuaScript(string str)
        {
            GameCtrl.luaEnv.DoString(str, "LuaTestScript", scriptEnv);
           
            Action luaAwake = scriptEnv.Get<Action>("awake");
            scriptEnv.Get("start", out luaStart);
            scriptEnv.Get("update", out luaUpdate);
            scriptEnv.Get("ondestroy", out luaOnDestroy);

            if (luaAwake != null)
            {
                luaAwake();
            }
        }

        private void Start()
        {
            if(luaStart != null)
            {
                luaStart();
            }
        }

        private void Update()
        {
            if(luaUpdate != null)
            {
                luaUpdate();
            }
            if(Time.time - MyLuaBehaviour.lastGCTime > GCInterval)
            {
                GameCtrl.luaEnv.Tick();
                MyLuaBehaviour.lastGCTime = Time.time;
            }
        }

        private void OnDestroy()
        {
            if(luaOnDestroy != null)
            {
                luaOnDestroy();
            }
            luaOnDestroy = null;
            luaUpdate = null;
            luaStart = null;
            scriptEnv.Dispose();
            injections = null;
        }
    }
}

