using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class DebugPanel : MonoBehaviour
{
    [Header("玩家数据")]
    public int chapter;//关卡
    public int mate;//材料
    public int diamond;//钻石
    public int exp;//经验


    // Use this for initialization
    void Start() {
        GetData();
    }

    // Update is called once per frame
    void Update() {

    }

    public void GetData()
    {
       
    }

    public void Refresh() {
       
    }
}
