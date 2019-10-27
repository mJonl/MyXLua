using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class UIMgr 
{
   
    //动态创建图片用这个函数,参数1图片名称，参数2为父类TransForm
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
        image.raycastTarget = false;//默认不接受点击事件 
        image.sprite = sprite;
        image.SetNativeSize();
    }

   
    //获取Sprite用这个函数
    public static Sprite LoadSprite(string spriteName)
    {
        return Resources.Load<GameObject>("Sprite/" + spriteName).GetComponent<SpriteRenderer>().sprite;
    }

}