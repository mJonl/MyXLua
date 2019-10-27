using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class FlyWords : MonoBehaviour
{
   
     GameObject prefabs;

    void Awake()
    {
        string prefabPath = "Prefab/FlyText";
        prefabs = Resources.Load(prefabPath) as GameObject;
       
    }
   
    public void SetNum(int num)
    {
        if(num >= 0)
        {
            setNumString(string.Format("<color=#ffffff><size=60>+ {0:d}</size></color>", num));
        }
        else
        {
            setNumString(string.Format("<color=#ff0000><size=60> {0:d}</size></color>", num));
        }
    }
    
    void setNumString(string str)
    {
       
        GameObject temp = GameObject.Instantiate(prefabs, transform);
        temp.GetComponent<FlyTextController>().SetLifeTime(1f);
        temp.transform.localPosition =     new Vector3(110,-17,0);
        temp.GetComponent<Text>().text = str;
       
    }
}
