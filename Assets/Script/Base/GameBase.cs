using UnityEngine;

/// <summary>
/// 游戏基类
/// </summary>
public class GameBase : MonoBehaviour
{
    protected void OnDestroy()
    {
        EventMgr.RemoveEventByObserver(this);
    }
}