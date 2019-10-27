using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

/// <summary>
/// 界面控制器
/// </summary>
public class DialogCtrl : GameBase
{
    private List<GameObject> mDialogs;
    private GameObject mMaskLayer;

    void Start()
    {
        mDialogs = new List<GameObject>();
        mMaskLayer = null;

        InitEvent();
    }

    void InitEvent()
    {
        EventMgr.AddEventListener(EventName.OPEN_DIALOG, this, OpenDialog);
        EventMgr.AddEventListener(EventName.CLOSE_DIALOG, this, CloseDialog);
    }

    /// <summary>
    /// 打开界面
    /// </summary>
    /// <param name="param">Parameter.</param>
    private void OpenDialog(object param)
    {
        DialogEvent data = param as DialogEvent;
        if(string.IsNullOrEmpty(data.mResPath))
            throw new Exception("resPath can't be null");

        //是否已经打开
        if (IsDialogOpened(data.mResPath))
            return;
        AudioMgr.GetInstance().PlayDialogSound();
        if (data.mDelay > float.Epsilon)
            transform.DOScale(1, data.mDelay).onComplete += () => { AddMaskLayer(); AddNewDialog(data);};
        else
        {
            AddMaskLayer();
            AddNewDialog(data);
        }
    }

    /// <summary>
    /// 添加界面
    /// </summary>
    /// <param name="param">传入数据</param>
    void AddNewDialog(DialogEvent data)
    {
        GameObject dialog = Instantiate(Resources.Load<GameObject>(data.mResPath));
        dialog.GetComponent<DialogBase>().ResPath = data.mResPath;
        dialog.GetComponent<DialogBase>().Param = data.mParam;
        dialog.transform.SetParent(gameObject.transform, false);
        mDialogs.Add(dialog);

        ExeAction(dialog, data.mIsAction);
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <param name="param">Parameter.</param>
    void CloseDialog(object param)
    {
        DialogEvent eve = param as DialogEvent;
        foreach (GameObject dialog in mDialogs)
        {
            if (dialog.GetComponent<DialogBase>().ResPath == eve.mResPath)
            {
                mDialogs.Remove(dialog);
                Destroy(dialog);
                HideMaskLayer();
                break;
            }
        }
    }
    //关闭所有弹框
    public void CloseAllDialog()
    {
        foreach (GameObject dialog in mDialogs)
        {
                mDialogs.Remove(dialog);
                Destroy(dialog);
                HideMaskLayer();
                break;
        }
    }
    /// <summary>
    /// 界面是否已经打开
    /// </summary>
    /// <param name="resPath">界面路径</param>
    bool IsDialogOpened(string resPath)
    {
        foreach (GameObject dialog in mDialogs)
        {
            if (dialog.GetComponent<DialogBase>().ResPath == resPath)
            {
                return true;
            }
        }
        return false;
    }

    void AddMaskLayer()
    {
        if (mMaskLayer == null)
        {
            mMaskLayer = Instantiate(Resources.Load<GameObject>("Dialog/Mask"));
            mMaskLayer.transform.SetParent(gameObject.transform, false);
        }
        else
        {
            mMaskLayer.SetActive(true);
        }
    }

    void HideMaskLayer()
    {
        if (mDialogs.Count <= 0 && mMaskLayer != null)
        {
            mMaskLayer.SetActive(false);
        }
    }

    void ExeAction(GameObject obj, bool isAction)
    {
        if (!isAction)
            return;

        obj.transform.GetComponent<Transform>().localPosition = new Vector2(0, 550);
        Sequence act = DOTween.Sequence();
        Tween tw1 = obj.transform.DOLocalMoveY(0, 0.31f, true).SetEase(Ease.OutBack);
        Tween tw2 = obj.transform.DOLocalMoveY(5, 0.07f, true).SetEase(Ease.OutBack);
        act.Append(tw1);
        act.Append(tw2);
    }
}