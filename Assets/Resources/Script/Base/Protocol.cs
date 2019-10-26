using System.Collections.Generic;

namespace MyExamp
{
    //配置lua脚本名称
    //key是gameobject的名称
    //value是lua脚本名,路径须在Resources下
    public class Protocol
    {
        
        public  static readonly Dictionary<string, string> ScriptName = new Dictionary<string, string>()
        {
            { "Canvas", "Script/UI/HomeView.lua"  },
           
            { "Canvas3", "aa" }
        };
    }

   /*
    //UDP协议号
    public struct Protocol_UDP
    {
        public const string
            //发送消息协议
            Req_Play_Togeter = "1001",//请求联机,1为请求联机,0为选择单机
           
            SURE_RECEIVE = "2001";//告知对方已收到信息

    }*/
}
