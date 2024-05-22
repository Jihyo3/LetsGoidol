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
    float[] itemTime = { 5f, 5f, 5f }; // ���� �����۸��� �ð� ����
    bool[] itemUse = { false , false, false }; // ���� �����۸��� ��������� �ƴ��� üũ



    private void Awake()
    {
        player = GetComponent<Transform>();
        FallingObject = GetComponentInChildren<GameObject>();
    }

    private void Update()
    {
        if (itemUse[0])itemTime[0] -= Time.deltaTime; // �������� ���ɶ� ���� �������� �ð��� �귯���ϴ�
        if (itemUse[1])itemTime[1] -= Time.deltaTime;

        if (PlayerTimeCheck(0) && itemUse[0]) // ������ ����� üũ�� ������ ���·� �ǵ����ϴ�
        {
            player.localScale = new Vector3(1, 1, 1);
            itemUse[0] = false; // ������ ���üũ �ʱ�ȭ
            itemTime[0] = 5f; // ����ѽð��� �ʱ�ȭ
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

    

    private void OnTriggerEnter2D(Collider2D collision) // ������ ���� Ʈ����
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



    private bool PlayerTimeCheck(int i) // ������ �ð� üũ �޼���
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
