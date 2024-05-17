using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    private Button startBtn;
    private Button joinBtn;

    public void StartBtnClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void JoinBtnClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
