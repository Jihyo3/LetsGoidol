using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    private Button startBtn;
    private Text btnTxt;

    private void Awake()
    {
        startBtn = GetComponent<Button>();
        btnTxt = GetComponentInChildren<Text>();
    }

    public void StartBtn()
    {
        DataManager.instance.difficulty = int.Parse(btnTxt.text);
        SceneManager.LoadScene("MainScene");        
    }
}
