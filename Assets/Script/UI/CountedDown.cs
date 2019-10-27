using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountedDown : MonoBehaviour {

    // Use this for initialization
    Image imgTimeCircle;
    Text txtTime;
    int mTime;
    int mTotalTime;
    public delegate void TimeCallBack(object ob);
    TimeCallBack timecallback;
    object timecallObj;
    void Awake()
    {
        imgTimeCircle = transform.Find("ImgTimeCircle").GetComponent<Image>();
        txtTime = transform.Find("txtLTime").GetComponent<Text>();
    }
    void Start () {
        mTime = 0;
        mTotalTime = 1;

    }

	public void SetTime(int nTime, TimeCallBack tc = null, object ob = null)
    {
       
        mTime = nTime;
        mTotalTime = nTime;
        timecallback = tc;
        timecallObj = ob;
        RetInit();
        StopAllCoroutines();
        StartCoroutine("StartTime");
    }

    void RetInit()
    {
        imgTimeCircle.fillAmount = 0;
        txtTime.text = string.Format("{0:d}S", mTime);
    }
    IEnumerator StartTime()
    {
        while(mTime > 0)
        {
            yield return new WaitForSeconds(1);
            mTime--;
            SetInfo();
        }

        if(timecallback != null)
        {
            timecallback(timecallObj);
        }
    }
    
    void SetInfo()
    {
        
        if(mTime <= 5)
        {
            txtTime.text = string.Format("<color=#ff0000><size=35>{0:d}s</size></color>", mTime);
        }
        else
        {
            txtTime.text = string.Format("<color=#07ABE1><size=30>{0:d}s</size></color>", mTime);
        }
        float totalTime = mTotalTime > 0 ? mTotalTime : 1;
        imgTimeCircle.fillAmount = 1 - mTime / totalTime;
    }

}
