using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class StartController : MonoBehaviour
{
    private Button startBtn;
    private Button joinBtn;
    private Button joinCloseBtn;
    [SerializeField] private GameObject joinBgImg;
    public TMP_InputField myIdField;
    public TMP_InputField myPassWordField;
    public PlayerJoinManager playerJoinManager;

    private string userInfoFilePath; 

    private void Start()
    {
        if (playerJoinManager != null)
        {
            playerJoinManager.UserAddedSuccessfully += OnUserAddedSuccessfully;
        }

        userInfoFilePath = Path.Combine(Application.persistentDataPath, "PlayerInfo.json");
    }

    public void StartBtnClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void JoinTxtClick()
    {
        joinBgImg.SetActive(true);
    }

    public void JoinCloseBtnClick()
    {
        joinBgImg.SetActive(false);
    }

    void OnUserAddedSuccessfully()
    {
        // ���� �߰� ���� �� joinBgImg ��Ȱ��ȭ
        joinBgImg.SetActive(false);
    }

    public void LoginBtnClick()
    {
        string enteredId = myIdField.text;
        string enteredPassword = myPassWordField.text;

        if (CheckLogin(enteredId, enteredPassword))
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            Debug.Log("���̵� �Ǵ� ��й�ȣ�� ��ġ���� �ʽ��ϴ�.");
        }
    }

    private bool CheckLogin(string enteredId, string enteredPassword)
    {
        // ����� ���� �ε�
        if (File.Exists(userInfoFilePath))
        {
            string jsonData = File.ReadAllText(userInfoFilePath);
            UserList savedUserList = JsonUtility.FromJson<UserList>(jsonData);

            if (savedUserList != null && savedUserList.users != null)
            {
                foreach (var user in savedUserList.users)
                {
                    if (user.id == enteredId && user.password == enteredPassword)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
