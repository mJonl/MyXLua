/// <summary>
/// 界面参数
/// </summary>
public class DialogEvent
{
    public string mResPath; //路径
    public object mParam; //传入数据
    public float mDelay; //延迟时间
    public bool mIsAction; //是否动画
}

/// <summary>
/// 弹窗基类
/// </summary>
public class DialogBase:GameBase
{
    protected object mParam;
    protected string mResPath;

    public string ResPath {
        // get => mResPath;
        get
        {
            return mResPath;
        }
        set
        {
            mResPath = value;
        }
        
   }
    public object Param {
        get
        {
            return mParam;
        }
        set
        {
            mParam = value;
        }
   }

    protected void CloseDialog()
    {
        EventMgr.DispachEvent(EventName.CLOSE_DIALOG, new DialogEvent { mResPath = ResPath });
    }
}