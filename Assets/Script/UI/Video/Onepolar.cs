
using UnityEngine;
//奔向极地视频具体类
public class Onepolar : IVideo
{
    GameObject mRamImageObj;
    VideoTool mVideTool;
    static Onepolar instance;
    public static Onepolar GetInstance()
    {
        if (instance == null) {
            instance = new Onepolar();
            instance.Init();
        } 
            return instance;
    }
    
    public void Init()
    {
        mRamImageObj = GameObject.FindWithTag("Video").gameObject;
        mVideTool = mRamImageObj.GetComponent<VideoTool>();
    }
    public void Play()
    {
        if(mVideTool == null)
        {
            mRamImageObj = GameObject.FindWithTag("Video").gameObject;
            mVideTool = mRamImageObj.GetComponent<VideoTool>();
        }
        mVideTool.PlayOnepolarVideo();
    }

    public void Stop()
    {   if(mVideTool != null)
             mVideTool.Stop();
    }
}
