using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterSkill : MonoBehaviour
{
    [SerializeField] private static GameObject poolObject;           // �������� ������Ʈ ���� ��ų�� ���� ����
    [SerializeField] private static Transform player;                // SizeDown ��ų�� ���� Transform ����
    [SerializeField] private static GameObject shieldObject;         // shield ��ų�� ���� ������Ʈ ����
    [SerializeField] private static Player _player;                  // SpeedUP ��ų�� ���� Player��ũ��Ʈ ����
    [SerializeField] private static GameObject text;                 // Ư���ɷ� ���� ��ų�� ���� TEXT������Ʈ ����

    private static int skillCount = 1;             // ��ų ��� ���� Ƚ��
    private int skillValue;

    private void Awake()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (skillCount == 1)
            {
                UseSkill(skillValue);
                skillCount--;
            }
        }

        // Ư���ɷ� ���� �ؽ�Ʈ�� ĳ���� �Ӹ� ���� ������ ��ġ ����
        text.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.0f, 0));
    }

    public static void UseSkill(int value)
    {
        switch (value)
        {
            case 0:
                Instance.StartCoroutine(DisablePoolObject());    // �������� ������Ʈ 3�ʰ� ����}
                break;
            case 1:
                Instance.StartCoroutine(SizeDown());             // �÷��̾� ũ�� 3�ʰ� ���̱�
                break;
            case 2:
                Instance.StartCoroutine(ActiveSheild());         // ���� ������Ʈ 3�ʰ� Ȱ��ȭ  (�±� UserShiled Ȯ��)
                break;
            case 3:
                Instance.StartCoroutine(SpeedUp());              // �̵� �ӵ� 3�ʰ� ����
                break;
            case 4:
                Instance.StartCoroutine(ActiveText());
                break;
        }
    }

    public static IEnumerator DisablePoolObject()
    {
        // Pool ������Ʈ�� ��Ȱ��ȭ
        poolObject.SetActive(false);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // Pool ������Ʈ�� �ٽ� Ȱ��ȭ
        poolObject.SetActive(true);
    }

    public static IEnumerator ActiveSheild()
    {
        // Shield ������Ʈ�� Ȱ��ȭ
        shieldObject.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // Shield ������Ʈ�� �ٽ� ��Ȱ��ȭ
        shieldObject.SetActive(false);
    }

    public static IEnumerator SizeDown()
    {
        // �÷��̾� ũ�� ���̱�
        player.localScale = new Vector3(0.5f, 0.5f, 1);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �÷��̾� ũ�� ����
        player.localScale = new Vector3(1, 1, 1);
    }

    public static IEnumerator SpeedUp()
    {
        // �÷��̾� �ӵ� ����
        _player.speed += 3;

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �÷��̾� �ӵ� ����
        _player.speed -= 3;
    }

    public static IEnumerator ActiveText()
    {
        // �ؽ�Ʈ Ȱ��ȭ
        text.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ ��Ȱ��ȭ
        text.SetActive(false);
    }

    private static CharacterSkill _instance;
    public static CharacterSkill Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡�� ���ο� �ν��Ͻ� ����
            if (_instance == null)
            {
                _instance = new CharacterSkill();
            }
            return _instance;
        }
    }
}