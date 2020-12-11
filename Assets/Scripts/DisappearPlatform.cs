using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _Disappear()
    {
        Destroy(gameObject);
        Debug.Log("destory");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("_Disappear", 1.0f);

    }
}
