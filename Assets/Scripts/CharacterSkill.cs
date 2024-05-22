using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterSkill : MonoBehaviour
{
    public GameObject poolObject;           // �������� ������Ʈ ���� ��ų�� ���� ����
    [SerializeField] private Transform player;               // SizeDown ��ų�� ���� Transform ����
    public GameObject shieldObject;         // shield ��ų�� ���� ������Ʈ ����
    [SerializeField] private Player _player;                  // SpeedUP ��ų�� ���� Player��ũ��Ʈ ����
    public Text text;                 // Ư���ɷ� ���� ��ų�� ���� TEXT������Ʈ ����
    public int skillValue;

    private int skillCount = 1;             // ��ų ��� ���� Ƚ��

    public void Initialize()
    {
        poolObject = GameObject.Find("PoolObject");
        shieldObject = GameObject.Find("ShieldObject");
        text = GameObject.Find("SkillText").GetComponent<Text>();

    }

    private void Awake()
    {
        player = GetComponent<Transform>();
    }

    private void Start()
    {
        Initialize();
        skillValue = PlayerIntro.skill;
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

    public void UseSkill(int value)
    {
        switch (value)
        {
            case 0:
                StartCoroutine(DisablePoolObject());    // �������� ������Ʈ 3�ʰ� ����}
                break;
            case 1:
                StartCoroutine(SizeDown());             // �÷��̾� ũ�� 3�ʰ� ���̱�
                break;
            case 2:
                StartCoroutine(ActiveSheild());         // ���� ������Ʈ 3�ʰ� Ȱ��ȭ  (�±� UserShiled Ȯ��)
                break;
            case 3:
                StartCoroutine(SpeedUp());              // �̵� �ӵ� 3�ʰ� ����
                break;
            case 4:
                StartCoroutine(ActiveText());
                break;
        }
    }

    public IEnumerator DisablePoolObject()
    {
        // Pool ������Ʈ�� ��Ȱ��ȭ
        poolObject.SetActive(false);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // Pool ������Ʈ�� �ٽ� Ȱ��ȭ
        poolObject.SetActive(true);

    }

    public IEnumerator ActiveSheild()
    {
        // Shield ������Ʈ�� Ȱ��ȭ
        shieldObject.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // Shield ������Ʈ�� �ٽ� ��Ȱ��ȭ
        shieldObject.SetActive(false);
    }

    public IEnumerator SizeDown()
    {
        // �÷��̾� ũ�� ���̱�
        player.localScale = new Vector3(0.5f, 0.5f, 1);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �÷��̾� ũ�� ����
        player.localScale = new Vector3(1, 1, 1);
    }

    public IEnumerator SpeedUp()
    {
        // �÷��̾� �ӵ� ����
        //_player.speed += 3;

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �÷��̾� �ӵ� ����
        //_player.speed -= 3;
    }

    public IEnumerator ActiveText()
    {
        // �ؽ�Ʈ Ȱ��ȭ
        text.gameObject.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ ��Ȱ��ȭ
        text.gameObject.SetActive(false);
    }
}