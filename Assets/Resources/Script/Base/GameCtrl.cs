using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExamp
{
    public class GameCtrl : MonoBehaviour
    {
        internal static XLua.LuaEnv luaEnv = new XLua.LuaEnv();//全局唯一的
        void Start()
        {
            // 恒定帧率
            Application.targetFrameRate = 60;
            //Screen.SetResolution(1920, 1080, true);//这是设置屏幕分辨率的方法，后面的false表示非全屏,测试用800*600
            Screen.SetResolution(800, 600, true);//这是设置屏幕分辨率的方法，后面的false表示非全屏,测试用800*600
            InitBattle();
            InitHomeView();
        }

        void InitBattle()
        {
            GameObject.Find("BattleCtrl").AddComponent<MyLuaBehaviour>().InitLuaScript();
            
        }
        void InitHomeView()
        {
            GameObject.Find("Canvas").AddComponent<MyLuaBehaviour>().InitLuaScript();
        }
    }
}

