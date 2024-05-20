using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    [SerializeField] GameObject overMenu; // 추후 변경예정

    private void Awake()
    {
        player = GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("badComments"))
        {
            Time.timeScale = 0f;
            Destroy(collision.gameObject);
            overMenu.SetActive(true); // 추후 변경예정 
        }
    }

    public void RetryBtnClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartSceneBtnClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
