
using UnityEngine;

public class FlyTextController : MonoBehaviour
{

    float speed;

    // Use this for initialization
    void Start()
    {
        speed = 30f;
       
        
    }

    public void SetLifeTime(float t = 1)
    {
        Invoke("DestroyGameObj", t);
    }
    void DestroyGameObj()
    {
        DestroyImmediate(gameObject);
    }
    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}

