using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class AudioMgr : MonoBehaviour
{
    static AudioMgr instance;
    //AudioListener audioListener;
    AudioSource audioSource;
    AudioSource videoSource;

    AudioClip timeAudio;
    AudioClip friction;
    AudioClip dialogAudio;
    AudioClip FallAudio;
    AudioClip HitAudio;
    AudioClip SnowAudio;
    AudioClip FogSnowAudio;
    AudioClip WinAudio;
    AudioClip LoseAudio;
    //AudioClip btnAudio;
    //     AudioClip linquAudio;


    //     AudioClip bossAudio;

    public static AudioMgr GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        //audioListener = GetComponent<AudioListener>();
        audioSource = GetComponent<AudioSource>();
        
        GameObject video = GameObject.FindWithTag("Video");

        videoSource = video.GetComponent<VideoPlayer>().GetComponent<AudioSource>();
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
//         btnAudio = Resources.Load<AudioClip>("Music/dianji");
//         linquAudio = Resources.Load<AudioClip>("Music/lingqujinbi");
        timeAudio = Resources.Load<AudioClip>("Audio/Clip/daojishi"); 
        friction = Resources.Load<AudioClip>("Audio/Clip/friction");
        dialogAudio = Resources.Load<AudioClip>("Audio/Clip/dialogAudio"); 
        FallAudio = Resources.Load<AudioClip>("Audio/Clip/FallAudio");
        HitAudio = Resources.Load<AudioClip>("Audio/Clip/Hit");
        SnowAudio = Resources.Load<AudioClip>("Audio/Clip/Snow");
        FogSnowAudio = Resources.Load<AudioClip>("Audio/Clip/FogSnow");
        WinAudio = Resources.Load<AudioClip>("Audio/Clip/Win"); 
        LoseAudio = Resources.Load<AudioClip>("Audio/Clip/Lose");
        //         bossAudio = Resources.Load<AudioClip>("Music/baojing");
    }

    

    //设置背景音乐开关
    public void OpenMusic(bool value)
    {
        PlayerData.Instance.IsOpenMusic = value;
    }

    //设置音效开关
    public void OpenSound(bool value)
    {
        PlayerData.Instance.IsOpenMusic = value;
    }

    public void PlayOneShot(AudioClip audioClip)
    {
       if (PlayerData.Instance.IsOpenMusic) audioSource.PlayOneShot(audioClip);
    }

    //开始背景音乐
    public void StartMusic()
    {
        if (PlayerData.Instance.IsOpenMusic)
        audioSource.Play();
    }

    //停止背景音乐
    public void StopMusic()
    {
        audioSource.Stop();
    }
    
    //开始视频声音
    public void StarVideoSound()
    {
        videoSource.Play();
    }
    //关闭视频声音
    public void StopVideoSound()
    {
        videoSource.Stop();
    }
    //按钮音效
    public void PlayBtnSound()
    {
        //PlayOneShot(btnAudio);
    }

    //领取金币,钻石
    public void PlayLinquSound()
    {
       // PlayOneShot(linquAudio);
    }

    //倒计时音效
    public void PlayTimeSound()
    {
        PlayOneShot(timeAudio);
    }

    //雪地摩擦音效
    public void PlayFriction()
    {
        PlayOneShot(friction);
    }
    //弹出界面音效
    public void PlayDialogSound()
    {
        PlayOneShot(dialogAudio);
    }
    //摔倒音效
    public void PlayFallSound()
    {
        PlayOneShot(FallAudio);
    }
    public void PlayHitSound()
    {
        PlayOneShot(HitAudio);
    }
    public void PlaySnowSound()
    {
        PlayOneShot(SnowAudio);
    }
    public void PlayFogSnowSound()
    {
        PlayOneShot(FogSnowAudio);
    }
    public void PlayWinSound()
    {
        PlayOneShot(WinAudio);
    }
    public void PlayLoseSound()
    {
        PlayOneShot(LoseAudio);
    }
    //boss警报
    public void PlayBossSound()
    {
        //PlayOneShot(bossAudio);
    }
}
