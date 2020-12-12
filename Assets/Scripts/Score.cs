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
