using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 界面管理
/// </summary>
public class DialogMgr
{
    private static DialogMgr instance;

    public static DialogMgr GetInstance()
    {
        if (instance == null)
        {
            instance = new DialogMgr();
        }
        return instance;
    }

    
    public void ShowNormalDig(string strT, string strD)
    {
        //PlayerData.Instance.IsTie = true;
        Dictionary<string, string> openWith = new Dictionary<string, string>();
        openWith.Add("title", strT);
        openWith.Add("strData", strD);
        EventMgr.DispachEvent(EventName.OPEN_DIALOG, 
            new DialogEvent { mResPath = "Dialog/NormalDialog" , mParam  = openWith });
    }
    public void ShowNormalDig(string strT, string strD, string outTime )
    {
        //PlayerData.Instance.IsTie = true;
        Dictionary<string, string> openWith = new Dictionary<string, string>();
        openWith.Add("title", strT);
        openWith.Add("strData", strD);
        openWith.Add("outTime", outTime);
        EventMgr.DispachEvent(EventName.OPEN_DIALOG,
            new DialogEvent { mResPath = "Dialog/NormalDialog", mParam = openWith });
    }

}
