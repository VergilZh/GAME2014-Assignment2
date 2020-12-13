/*
    File Name: Score.cs
    Student Name: Han Zhan
    Student ID: 101141379
    Date last Modified: 2020/12/13
    Program description: Get player score.
    Revision History:
    2020/12/11 Add gameScore to check player mark.
    2020/12/11 UI Can get gameScore update and show it.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int gameScore;
    public Text showScore;
    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        showScore.text = gameScore.ToString();
    }
}
