using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace MyExamp
{
    [LuaCallCSharp]//教程说如果不打，就用性能较低的方式访问
    public class TestExp : MonoBehaviour
    {
        public int index;
        public int Add(int a, int b)
        {
            return a + b;
        }
        static public void  StaFun(string s)
        {
            Debug.Log(s);
        }
    }
}

