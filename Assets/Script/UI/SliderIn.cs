using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderIn : MonoBehaviour {

    Image SliderHillFront;
    Transform SliderFront;
    Transform SliderBg;
    float sliLength = 730;
    const float sliH = 29;
    void Awake()
    {
        SliderHillFront = transform.Find("SliderHillBg/SliderHillFront").GetComponent<Image>();
        SliderBg        = transform.Find("SliderBg");
        SliderFront     = transform.Find("SliderBg/SliderFront");

        var rt = SliderBg.GetComponent<RectTransform>();
        
        sliLength = SliderBg.GetComponent<RectTransform>().rect.xMax;
        
    }
    public void SetValue(float vData)
    {
        SliderHillFront.fillAmount = vData;
        float width = vData * sliLength;
        SliderFront.GetComponent<RectTransform>().sizeDelta = new Vector2(width, sliH);
    }
}
