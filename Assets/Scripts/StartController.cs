using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    private Button startBtn;

    public void StartBtnClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
