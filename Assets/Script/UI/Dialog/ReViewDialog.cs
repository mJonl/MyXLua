using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ReViewDialog : DialogBase
{
    SliderIn sl;
    
    const int showTime = 3;
    
    Transform gridtransform;
    int mIndex;
    int mViewCount;
    const int perWidth = 523;
    void Awake()
    {
       
        sl                  = transform.Find("DiglogBg/Slider").GetComponent<SliderIn>();
        gridtransform       = transform.Find("DiglogBg/ScrollRect/Grid");
        EventMgr.AddEventListener(EventName.Dis_For, this, OnCloseD);
       // EventMgr.AddEventListener(EventName.Dis_Left, this, OnDisLeft);
       // EventMgr.AddEventListener(EventName.Dis_Right, this, OnDisRight);
    }
    void Start()
    {
        for (int i = 0; i < gridtransform.childCount; i++)
        {
            GameObject gameObj = gridtransform.GetChild(i).gameObject;
            DestroyImmediate(gameObj);
        }
        mIndex = 0;
        
        sl.SetValue(1);

        PlayerData.Instance.AddReViewList("polarization");
        PlayerData.Instance.AddReViewList("sea gull");
        PlayerData.Instance.AddReViewList("seal");
        PlayerData.Instance.AddReViewList("StormSnow");
        PlayerData.Instance.AddReViewList("Thethief");
        
        mViewCount = PlayerData.Instance.ReViewList.Count;
        InitData();
        StopCoroutine("NextView");
        StartCoroutine("NextView");

    }

    void InitData()
    {
        
        gridtransform.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, mViewCount * perWidth);

        for (int i = 0; i < mViewCount; i++)
        {
            GameObject temp = new GameObject();
            UIMgr.CreatImage(PlayerData.Instance.ReViewList[i], gridtransform, ref temp);
            
        }
    }

   
    void OnDisLeft(object obj)
    {
        if (mIndex == 0) return;
        mIndex--;
        MoveITo(1);
       
    }

    void OnDisRight(object obj = null)
    {
        if (mIndex == mViewCount - 1) return;
        mIndex++;
        MoveITo(-1);
        
    }

    void MoveITo(int fu)
    {
        Vector3 newPos = gridtransform.localPosition + new Vector3(perWidth * fu, 0, 0);
        
       
        DOTween.To(() => gridtransform.localPosition, x => gridtransform.localPosition = x, newPos, 1).OnComplete(UpdateIndex);
    }

    void UpdateIndex()
    {
        StopCoroutine("NextView");
        StartCoroutine("NextView");
    }

    IEnumerator NextView()
    {
        yield return new WaitForSeconds(showTime);
        if (mIndex == mViewCount - 1)
        {
            CloseView();
        }
        else
        {
            OnDisRight();
        }
        
    }

    void CloseView()
    {
        CloseDialog();
        EventMgr.DispachEvent(EventName.BEGIN_GAME);
    }
    void OnCloseD(object obj)
    {

        CloseView();
    }


}
