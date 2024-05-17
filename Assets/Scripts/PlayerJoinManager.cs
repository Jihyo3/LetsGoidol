using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class User
{
    public string id;
    public string password;
}

[System.Serializable]
public class UserList
{
    public List<User> users;
}

public class PlayerJoinManager : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField passWordField;
    public Text idWarningTxt;
    public Text passWordWarningTxt;
    public Button joinCheckBtn;

    private string userInfoFilePath;
    public event Action UserAddedSuccessfully;

    void Start()
    {
        userInfoFilePath = Path.Combine(Application.persistentDataPath, "PlayerInfo.json");

        if (!File.Exists(userInfoFilePath))
        {
            UserList emptyUserList = new UserList { users = new List<User>() }; 
            string emptyJson = JsonUtility.ToJson(emptyUserList, true); 
            File.WriteAllText(userInfoFilePath, emptyJson); 
        }
        idWarningTxt.gameObject.SetActive(false);
        passWordWarningTxt.gameObject.SetActive(false);
        joinCheckBtn.onClick.AddListener(OnJoinCheckBtnClick);
    }

    void OnJoinCheckBtnClick()
    {
        string id = idField.text;
        string password = passWordField.text;

        if (IdCheck(id))
        {
            idWarningTxt.gameObject.SetActive(true);
        }
        else
        {
            idWarningTxt.gameObject.SetActive(false);
        }

        if (!PasswordCheck(password))
        {
            passWordWarningTxt.gameObject.SetActive(true);
        }
        else
        {
            passWordWarningTxt.gameObject.SetActive(false);
        }

        if (!IdCheck(id) && PasswordCheck(password))
        {
            SaveUser(id, password);
            UserAddedSuccessfully?.Invoke();
        }
    }

    bool IdCheck(string id)
    {
        if (File.Exists(userInfoFilePath))
        {
            string json = File.ReadAllText(userInfoFilePath);
            UserList userList = JsonUtility.FromJson<UserList>(json);
            if (userList != null && userList.users != null)
            {
                foreach (var user in userList.users)
                {
                    if (user.id == id)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    bool PasswordCheck(string password)
    {
        return password.Length >= 4 && password.Length <= 12;
    }
    void SaveUser(string id, string password)
    {
        if (string.IsNullOrEmpty(userInfoFilePath))
        {
            Debug.LogError("userInfoFilePath is null or empty!");
            return;
        }

        User newUser = new User { id = id, password = password };
        UserList userList;

        if (File.Exists(userInfoFilePath))
        {
            string json = File.ReadAllText(userInfoFilePath);

            if (string.IsNullOrEmpty(json))
            {
                userList = new UserList { users = new List<User>() };
            }
            else
            {
                userList = JsonUtility.FromJson<UserList>(json);
            }
        }
        else
        {
            userList = new UserList { users = new List<User>() };
        }

        if (userList.users == null)
        {
            userList.users = new List<User>();
        }

        userList.users.Add(newUser);
        string newJson = JsonUtility.ToJson(userList, true);
        File.WriteAllText(userInfoFilePath, newJson);
    }
}
