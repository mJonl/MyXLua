


using System.Collections.Generic;
using UnityEngine;

public class PlayerData {

    #region instance
    static PlayerData instance;
    public static PlayerData Instance
    {
        get
        {
            if (instance == null) instance = new PlayerData();
            return instance;
        }
    }
    public PlayerData()
    {
        IsHadPlayer = false;
        misOppOnLine = false;
        misOpenMusic = true;
        mScore = 100;
        mHightScore = 100;
        misPlaying = false;
        misTie = false;
        misJumpStudy = false;
        misInFallOverTime = false;
        mClothColorIndex = 0;
        mOppClothColorIndex = 0;
        mReViewList.Clear();
        popTipDic = new Dictionary<string, string>
        {
            {"storm",       "雾雪天气提示|前方雾雪覆盖,注意控制方向!" },
            {"flyice",      "浮冰裂缝区提示|前方地域出现部分浮冰和裂缝,注意控制速度及方向!" },
            {"smallpen",    "小企鹅出没区|前方有小企鹅出没,注意控制方向!" },
            {"curve",       "弯道操作提示|前方连续弯道,注意控制方向!" },
            {"U_curve",     "U形弯道提示|前方进入动物居住区，请注意躲避!|帝企鹅|diqie" },
            {"storm_img",  "暴风雪提示|暴风雪来临，请注意躲避!|注意蹲下|xiadun" },
        };
    }
    #endregion
    #region data
    public const int PlayTime = 90;//游戏时间
    bool mishadPlayer;
    public bool IsHadPlayer
    {
        get { return mishadPlayer; }
        set { mishadPlayer = value; }
    }
    bool misOppOnLine;
    public bool IsOppOnLine
    {
        get { return misOppOnLine; }
        set { misOppOnLine = value; }
    }
    bool misStudy;
    public bool IsStudy
    {
        get { return misStudy; }
        set { misStudy = value; }
    }
    bool misSingle;
    public bool IsSingle
    {
        get { return misSingle; }
        set { misSingle = value; }
    }
    bool misFirstSee;
    public bool IsFirstSee
    {
        get { return misFirstSee; }
        set { misFirstSee = value; }
    }
    bool misOpenMusic;
    public bool IsOpenMusic
    {
        get { return misOpenMusic; }
        set { misOpenMusic = value; }
    }
    int mScore;
    public int Score
    {
        get { return mScore; }
        set { mScore = value; 
		}
    }
    public void AddScore(int sco)
    {
        if (!misPlaying) return;
        mScore += sco;
        if(mScore > mHightScore)
        {
            mHightScore = mScore;
        }
        if(mScore < 0) { mScore = 0; }
        EventMgr.DispachEvent(EventName.Update_Score, sco);
    }
    public const int mGameTime = 90;
    int mHightScore;
    public int HightScore
    {
        get { return mHightScore; }
        
    }
    GameObject mPlayerObj;
    public GameObject PlayerObj
    {
        get { return mPlayerObj; }
        set { mPlayerObj = value; }
    }
    bool misPlaying;
    public bool IsPlaying
    {
        get { return misPlaying; }
        set { misPlaying = value; }
    }
    bool misTie;
    public bool IsTie
    {
        get { return misTie; }
        set { misTie = value; }
    }
    bool misJumpStudy;
    public bool IsJumpStudy
    {
        get { return misJumpStudy; }
        set { misJumpStudy = value; }
    }
    int mClothColorIndex;
    public int ClothColorIndex
    {
        get { return mClothColorIndex; }
        set { mClothColorIndex = value; }
    }
    int mOppClothColorIndex;
    public int OppClothColorIndex
    {
        get { return mOppClothColorIndex; }
        set { mOppClothColorIndex = value; }
    }
    List<string> mReViewList = new List<string>();
    public List<string> ReViewList
    {
        get { return mReViewList; }
    }
    public void AddReViewList(string str) { mReViewList.Add(str); }
    public Dictionary<string, string> popTipDic;
    public const int NoPlayerOutTime = 30;
    bool misInFallOverTime;
    public bool IsFallOverTime
    {
        get { return misInFallOverTime; }
        set { misInFallOverTime = value; }
    }
    #endregion


}
