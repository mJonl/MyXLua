using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class UIMgr 
{
   

    public static void CreatImage(string img, Transform tran, ref GameObject go)
    {
        CreatImage(LoadSprite(img),tran, ref  go);
    }
    static void CreatImage(Sprite sprite, Transform tran, ref GameObject go)
    {
        go = new GameObject(sprite.name);
        //go.layer = LayerMask.NameToLayer("UILayer");
        go.transform.parent = tran;
        go.transform.localScale = Vector3.one;
        Image image = go.AddComponent<Image>();
        image.raycastTarget = false;//Ĭ�ϲ����ܵ���¼� 
        image.sprite = sprite;
        image.SetNativeSize();
    }

   
    
    public static Sprite LoadSprite(string spriteName)
    {
        return Resources.Load<GameObject>("Sprite/" + spriteName).GetComponent<SpriteRenderer>().sprite;
    }

}