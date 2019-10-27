using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class FlyTipWords : MonoBehaviour
{
    
     GameObject prefabs;
     Transform canvasTransform;



    void Awake()
    {
        string prefabPath       = "Prefab/FlyText";
        prefabs                 = Resources.Load(prefabPath) as GameObject;
        canvasTransform         = GameObject.Find("Canvas").transform;
    }
   
  
    public void setString(string str)
    {
        GameObject temp = GameObject.Instantiate(prefabs, canvasTransform);
       
        
        temp.transform.position = transform.position;
        temp.GetComponent<FlyTextController>().SetLifeTime(3f);
        //temp.transform.localPosition = new Vector3(0, 300, 0);
        temp.GetComponent<Text>().text = str;
       
    }
}
