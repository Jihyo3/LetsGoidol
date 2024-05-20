using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    [SerializeField] GameObject overMenu; // ���� ���濹��

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
            overMenu.SetActive(true); // ���� ���濹�� 
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
