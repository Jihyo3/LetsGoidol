using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterSkill : MonoBehaviour
{
    public GameObject poolObject;           // 떨어지는 오브젝트 제거 스킬을 위해 연결
    private Transform player;               // SizeDown 스킬을 위해 Transform 연결
    public GameObject shieldObject;         // shield 스킬을 위해 오브젝트 연결
    public Player _player;                  // SpeedUP 스킬을 위해 Player스크립트 연결
    public GameObject text;                       // 특수능력 없음 스킬을 위해 TEXT오브젝트 연결

    private int skillCount = 1;             // 스킬 사용 가능 횟수

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
        // 캐릭터 구분으로 호출 수정 필요
        //StartCoroutine(DisablePoolObject());    // 떨어지는 오브젝트 3초간 제거
        //StartCoroutine(SizeDown());             // 플레이어 크기 3초간 줄이기
        //StartCoroutine(ActiveSheild());         // 쉴드 오브젝트 3초간 활성화  (태그 UserShiled 확인)
        //StartCoroutine(SpeedUp());              // 이동 속도 3초간 증가
        StartCoroutine(ActiveText());
    }
    
    IEnumerator DisablePoolObject()
    {
        // Pool 오브젝트를 비활성화
        poolObject.SetActive(false);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // Pool 오브젝트를 다시 활성화
        poolObject.SetActive(true);
    }

    IEnumerator ActiveSheild()
    {
        // Shield 오브젝트를 활성화
        shieldObject.SetActive(true);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // Shield 오브젝트를 다시 비활성화
        shieldObject.SetActive(false);
    }

    IEnumerator SizeDown()
    {
        // 플레이어 크기 줄이기
        player.localScale = new Vector3(0.5f, 0.5f, 1);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 플레이어 크기 복구
        player.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator SpeedUp()
    {
        // 플레이어 속도 증가
        _player.speed += 3;

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 플레이어 속도 감소
        _player.speed -= 3;
    }

    IEnumerator ActiveText()
    {
        // 텍스트 활성화
        text.SetActive(true);

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트 비활성화
        text.SetActive(false);
    }
}
