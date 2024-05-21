using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterSkill : MonoBehaviour
{
    public GameObject poolObject;           // �������� ������Ʈ ���� ��ų�� ���� ����
    private Transform player;               // SizeDown ��ų�� ���� Transform ����
    public GameObject shieldObject;         // shield ��ų�� ���� ������Ʈ ����
    public Player _player;                  // SpeedUP ��ų�� ���� Player��ũ��Ʈ ����
    public GameObject text;                       // Ư���ɷ� ���� ��ų�� ���� TEXT������Ʈ ����

    private int skillCount = 1;             // ��ų ��� ���� Ƚ��

    private void Awake()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(skillCount == 1)
            {
                UseSkill();
                skillCount--;
            }
        }
    }

    void UseSkill()
    {
        // ĳ���� �������� ȣ�� ���� �ʿ�
        //StartCoroutine(DisablePoolObject());    // �������� ������Ʈ 3�ʰ� ����
        //StartCoroutine(SizeDown());             // �÷��̾� ũ�� 3�ʰ� ���̱�
        //StartCoroutine(ActiveSheild());         // ���� ������Ʈ 3�ʰ� Ȱ��ȭ  (�±� UserShiled Ȯ��)
        //StartCoroutine(SpeedUp());              // �̵� �ӵ� 3�ʰ� ����
        StartCoroutine(ActiveText());
    }
    
    IEnumerator DisablePoolObject()
    {
        // Pool ������Ʈ�� ��Ȱ��ȭ
        poolObject.SetActive(false);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // Pool ������Ʈ�� �ٽ� Ȱ��ȭ
        poolObject.SetActive(true);
    }

    IEnumerator ActiveSheild()
    {
        // Shield ������Ʈ�� Ȱ��ȭ
        shieldObject.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // Shield ������Ʈ�� �ٽ� ��Ȱ��ȭ
        shieldObject.SetActive(false);
    }

    IEnumerator SizeDown()
    {
        // �÷��̾� ũ�� ���̱�
        player.localScale = new Vector3(0.5f, 0.5f, 1);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �÷��̾� ũ�� ����
        player.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator SpeedUp()
    {
        // �÷��̾� �ӵ� ����
        _player.speed += 3;

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �÷��̾� �ӵ� ����
        _player.speed -= 3;
    }

    IEnumerator ActiveText()
    {
        // �ؽ�Ʈ Ȱ��ȭ
        text.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ ��Ȱ��ȭ
        text.SetActive(false);
    }
}
