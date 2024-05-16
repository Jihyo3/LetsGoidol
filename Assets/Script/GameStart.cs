using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button startBtn;

    public void StartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
