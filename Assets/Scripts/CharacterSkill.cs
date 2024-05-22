using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterSkill : MonoBehaviour
{
    public GameObject poolObject;           // 떨어지는 오브젝트 제거 스킬을 위해 연결
    [SerializeField] private Transform player;               // SizeDown 스킬을 위해 Transform 연결
    public GameObject shieldObject;         // shield 스킬을 위해 오브젝트 연결
    [SerializeField] private Player _player;                  // SpeedUP 스킬을 위해 Player스크립트 연결
    public Text text;                 // 특수능력 없음 스킬을 위해 TEXT오브젝트 연결
    public int skillValue;

    private int skillCount = 1;             // 스킬 사용 가능 횟수

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

        // 특수능력 없음 텍스트가 캐릭터 머리 위에 나오게 위치 설정
        text.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.0f, 0));
    }

    public void UseSkill(int value)
    {
        switch (value)
        {
            case 0:
                StartCoroutine(DisablePoolObject());    // 떨어지는 오브젝트 3초간 제거}
                break;
            case 1:
                StartCoroutine(SizeDown());             // 플레이어 크기 3초간 줄이기
                break;
            case 2:
                StartCoroutine(ActiveSheild());         // 쉴드 오브젝트 3초간 활성화  (태그 UserShiled 확인)
                break;
            case 3:
                StartCoroutine(SpeedUp());              // 이동 속도 3초간 증가
                break;
            case 4:
                StartCoroutine(ActiveText());
                break;
        }
    }

    public IEnumerator DisablePoolObject()
    {
        // Pool 오브젝트를 비활성화
        poolObject.SetActive(false);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // Pool 오브젝트를 다시 활성화
        poolObject.SetActive(true);

    }

    public IEnumerator ActiveSheild()
    {
        // Shield 오브젝트를 활성화
        shieldObject.SetActive(true);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // Shield 오브젝트를 다시 비활성화
        shieldObject.SetActive(false);
    }

    public IEnumerator SizeDown()
    {
        // 플레이어 크기 줄이기
        player.localScale = new Vector3(0.5f, 0.5f, 1);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 플레이어 크기 복구
        player.localScale = new Vector3(1, 1, 1);
    }

    public IEnumerator SpeedUp()
    {
        // 플레이어 속도 증가
        //_player.speed += 3;

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 플레이어 속도 감소
        //_player.speed -= 3;
    }

    public IEnumerator ActiveText()
    {
        // 텍스트 활성화
        text.gameObject.SetActive(true);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트 비활성화
        text.gameObject.SetActive(false);
    }
}