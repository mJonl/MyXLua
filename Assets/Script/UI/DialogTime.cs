using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class DialogTime : DialogBase
{
    //GameObject txtTime;
   
    Image mimg_time;
    int frameCount;
    
    int leaveTime;
    
    void Awake()
    {
        leaveTime = 5;
       
        mimg_time = transform.Find("img_time").GetComponent<Image>();
    }
    // Use this for initialization
    void Start() {
        if(Param != null)
        {
            leaveTime = (int)Param;
        }
        
        InitData();
        InitUI();
        
    }

    void InitData() {
        frameCount=0;
        
    }

    void InitUI(){
        PlayerData.Instance.IsFallOverTime = true;
        mimg_time.sprite = UIMgr.LoadSprite(string.Format("w{0:d}", leaveTime));
        StopCoroutine("TickTime");
        StartCoroutine("TickTime");
        //Invoke("StartAction", 0.5f);
    }

    IEnumerator TickTime()
    {
        while(leaveTime > 0)
        {
            mimg_time.sprite = UIMgr.LoadSprite(string.Format("w{0:d}", leaveTime));
            yield return new WaitForSeconds(1);
            leaveTime--;
        }
        ToResult();
    }
    void ToResult()
    {
        PlayerData.Instance.IsFallOverTime = false;
        AudioMgr.GetInstance().PlayTimeSound();
        CloseDialog();
    }
}
