/*
    File Name: ButtonManagentment.cs
    Student Name: Han Zhan
    Student ID: 101141379
    Date last Modified: 2020/12/13
    Program description: Managent all button.
    Revision History:
    2020/12/11 delete other button scripts, move button at here.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnInstructionButtonPressed()
    {
        SceneManager.LoadScene("Instruction");
    }

    public void OnGameOverButtonPressed()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
}
