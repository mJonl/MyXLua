using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(RawImage), typeof(VideoPlayer))]
public class VideoTool : MonoBehaviour
{
    public VideoClip clip;
    [HideInInspector] [SerializeField] VideoClip oldClip;
    [HideInInspector] public VideoPlayer videoPlayer;
    [HideInInspector] public RenderTexture rendererTexture;

    [Header("Debug")]
    public bool doPlay;
    public bool doStop;

    private void Awake()
    {
        Init((int)clip.width, (int)clip.height);
    }

    private void OnValidate()
    {
        if (oldClip != clip && clip != null)
        {
            oldClip = clip;
            Init((int)clip.width, (int)clip.height);
        }

        if (doPlay)
        {
            doPlay = false;
            Play();
        }
        else if (doStop)
        {
            doStop = false;
            Stop();
        }
    }

    [ContextMenu("CreateTexture")]
    void CreateTexture()//生成与RectTransform一样大小的RendererTexture
    {
        var rectTran = GetComponent<RectTransform>();
        Init((int)rectTran.rect.width, (int)rectTran.rect.height);
    }

    [ContextMenu("CreateAudio")]
    void CreateAudio()
    {
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        var audioSource = GetComponent<AudioSource>();
        if (!audioSource) audioSource = gameObject.AddComponent<AudioSource>();
        videoPlayer.controlledAudioTrackCount = 1;
        videoPlayer.SetTargetAudioSource(0, audioSource);
    }

    void Init(int w,int h)
    {
        rendererTexture = new RenderTexture(w, h, 32, RenderTextureFormat.ARGB32);
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.clip = clip;
        videoPlayer.targetTexture = rendererTexture;
        GetComponent<RawImage>().texture = rendererTexture;
      //  PlayVideoOnStart(videoPlayer);
        
        
    }

    void Play()
    {
        videoPlayer.Stop();
        videoPlayer.Play();
    }
    void Pause()
    {
        videoPlayer.Pause();
    }
    public void Stop()
    {
        videoPlayer.Stop();
        gameObject.SetActive(false);
    }
    
    public void PlayOnepolarVideo()
    {
        gameObject.SetActive(true);
        PlayVideoOnStart(videoPlayer);
    }
    /// <summary>
    /// 视频播放,防止开头出现尾帧
    /// </summary>
    public static IEnumerator PlayVideoOnStart(VideoPlayer vp)
    {
        var oldPos = vp.transform.localPosition;
        vp.transform.localPosition = new Vector3(100000,0);
        vp.gameObject.SetActive(true);
        vp.Stop();
        vp.Play();
        while (!vp.isPrepared)
        {
            yield return null;
            vp.Play();
        }
        yield return null;
        vp.transform.localPosition = oldPos;
        //if (vp.gameObject.activeSelf)
        //{
        //    vp.Stop();
        //    vp.Play();
        //}
        //else
        //{
        //    var canvasRenderer = vp.GetComponent<CanvasRenderer>();
        //    canvasRenderer.SetAlpha(0);
        //    vp.gameObject.SetActive(true);
        //    vp.Play();
        //    while (!vp.isPrepared)
        //    {
        //        yield return null;
        //    }
        //    yield return null;
        //    canvasRenderer.SetAlpha(1);
        //}
    }
}



