using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PlayerIntro : MonoBehaviour
{
    public Button button;
    private bool insu = false;
    private bool sujeong = false;
    private bool jihyo = false;
    private bool ygs = false;
    private bool puk = false;
    private string selectplayer;
    private GameObject selectplayerimage;
    public Sprite[] images;
    public GameObject popupMenu;
    public Image DefaultPlayerImg;
    private bool isPopupMenu = false;
    public static int skill;

    public GameObject[] players;

    public void Clickbtn(int skillValue)
    {
        if (insu)
        {
            selectplayer = players[0].name;
        }
        else if (sujeong)
        {
            selectplayer = players[1].name;

        }
        else if (jihyo)
        {
            selectplayer = players[2].name;

        }
        else if (puk)
        {
            selectplayer = players[3].name;
        }
        else
        {
            selectplayer = players[4].name;

        }
    }

    public void Join()
    {

        if (selectplayer != null)
        {
            PlayerPrefs.SetString("selectPlayer", selectplayer);
            PlayerPrefs.SetFloat("PlayerPositionX", 0);
            PlayerPrefs.SetFloat("PlayerPositionY", 0);
            PlayerPrefs.SetFloat("PlayerPositionZ", 0);

            SceneManager.LoadScene("MainScene2 1");
        }
        else
        {
            Debug.Log("아이돌이 선택되지 않았습니다!");
        }
    }
    public void selectedinsu()
    {
        insu = true;
        sujeong = false;
        jihyo = false;
        ygs = false;
        puk = false;

        DefaultPlayerImg.sprite = images[0];
        skill = 0;
        Clickbtn(skill);
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void selectedsujeong()
    {
        insu = false;
        sujeong = true;
        jihyo = false;
        ygs = false;
        puk = false;

        DefaultPlayerImg.sprite = images[1];
        skill = 1;
        Clickbtn(skill);
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void selectedjihyo()
    {
        insu = false;
        sujeong = false;
        jihyo = true;
        ygs = false;
        puk = false;

        DefaultPlayerImg.sprite = images[2];
        skill = 2;
        Clickbtn(skill);
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void selectedpuk()
    {
        insu = false;
        sujeong = false;
        jihyo = false;
        ygs = false;
        puk = true;

        DefaultPlayerImg.sprite = images[3];
        skill = 3;
        Clickbtn(skill);
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void selectedygs()
    {
        insu = false;
        sujeong = false;
        jihyo = false;
        ygs = true;
        puk = false;

        DefaultPlayerImg.sprite = images[4];
        skill = 4;
        Clickbtn(skill);
        isPopupMenu = false;
        popupMenu.SetActive(false);
    }

    public void PopupMenuClick()
    {
        popupMenu.SetActive(true);
        DefaultPlayerImg.gameObject.SetActive(true);
        if(!isPopupMenu)
        {
            isPopupMenu = true;
            popupMenu.SetActive(true);
            DefaultPlayerImg.gameObject.SetActive(true);
        }
        else
        {
            isPopupMenu = false;
            popupMenu.SetActive(false);
        }
    }
}