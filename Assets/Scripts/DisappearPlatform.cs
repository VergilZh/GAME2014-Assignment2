/*
    File Name: DisappearPlatform.cs
    Student Name: Han Zhan
    Student ID: 101141379
    Date last Modified: 2020/12/13
    Program description: Make a platform can disappear.
    Revision History:
    2020/12/11 Add disappear platform.
 */

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
