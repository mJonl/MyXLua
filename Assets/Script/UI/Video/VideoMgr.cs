
public class VideoMgr {

    IVideo mIvideo;
    static VideoMgr instance;

    public static VideoMgr GetInstance()
    {
        if (instance == null) instance = new VideoMgr(Onepolar.GetInstance());
        return instance;
    }
    public VideoMgr(IVideo vi)
    {
        mIvideo = vi;
    }
    public void PlayVideo()
    {
        if(mIvideo != null)
            mIvideo.Play();
    }
    public void StopVideo()
    {
        if (mIvideo != null)
            mIvideo.Stop();
    }
}
