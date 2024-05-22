using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject FallingObject;
    float[] itemTime = { 5f, 5f, 5f }; // 각각 아이템마다 시간 적용
    bool[] itemUse = { false , false, false }; // 각각 아이템마다 사용중인지 아닌지 체크



    private void Awake()
    {
        player = GetComponent<Transform>();
        FallingObject = GetComponentInChildren<GameObject>();
    }

    private void Update()
    {
        if (itemUse[0])itemTime[0] -= Time.deltaTime; // 아이템이 사용될때 각각 아이템의 시간이 흘러갑니다
        if (itemUse[1])itemTime[1] -= Time.deltaTime;

        if (PlayerTimeCheck(0) && itemUse[0]) // 아이템 사용후 체크해 이전의 상태로 되돌립니다
        {
            player.localScale = new Vector3(1, 1, 1);
            itemUse[0] = false; // 아이템 사용체크 초기화
            itemTime[0] = 5f; // 사용한시간은 초기화
        }
        if (PlayerTimeCheck(1) && itemUse[1])
        {
            shield.SetActive(false);
            itemUse[1] = false;
            itemTime[1] = 5f;
        }
        if (PlayerTimeCheck(2) && itemUse[2])
        {
            FallingObject.SetActive(true);
            itemUse[2] = false;
        }

    }

    

    private void OnTriggerEnter2D(Collider2D collision) // 아이템 감지 트리거
    {
        if (collision.CompareTag("SizeDownItem"))
        {
            player.localScale = new Vector3(0.5f,0.5f,1);
            itemUse[0] = true;
        }

        else if (collision.CompareTag("Shield"))
        {
            shield.SetActive(true);
            itemUse[1] = true;
        }

        else if (collision.CompareTag("ObjectDel"))
        {
            FallingObject.SetActive(false);
            itemUse[2] = true;
        }

    }



    private bool PlayerTimeCheck(int i) // 아이템 시간 체크 메서드
    {
        if (i == 2) return true;
        if (itemTime[i] <= 0f)
        {
            
            return true;           
        }
        else
        {
            return false;
        }
    }
}
