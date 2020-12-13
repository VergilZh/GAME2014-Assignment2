/*
    File Name: MovingPlatformControlller.cs
    Student Name: Han Zhan
    Student ID: 101141379
    Date last Modified: 2020/12/13
    Program description: Make platform movement.
    Revision History:
    2020/12/11 Add moving platform.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformControlller : MonoBehaviour
{
    public Transform start;
    public Transform end;

    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = end.position - start.position;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        transform.position = new Vector3(start.position.x + Mathf.PingPong(Time.time, distance.x), start.position.y, 0.0f);
    }
}
