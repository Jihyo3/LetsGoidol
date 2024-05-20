using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    // 인스턴스할 프리팹을 저장할 변수
    public GameObject fallingObject;

    // 배열로 아이템 프리팹을 저장할 변수
    // GameManager 인스펙터 창에서 증가 감소 가능
    public GameObject[] falling_ItemPrefabs;

    // 객체 풀링을 위한 ObjectPool 인스턴스
    public ObjectPool objectPool;

    private void Awake()
    {
        // 프레임 60으로 제한
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        // 메서드 반복 호출 키워드 ( FallingObject / 0.0f초 딜레이 / 1.0f초 반복 )
        InvokeRepeating("FallingObjectCreat", 0.0f, 1.0f);
        // RandomItem 메서드를 호출 / 게임 시작 3초 뒤에 랜덤 아이템 생성 / 5초마다 랜덤 아이템 생성
        // 아이템의 크기 or 첫 생성 시간을 조절하여 오브젝트가 겹치지 않게 할 수 있습니다.
        InvokeRepeating("RandomItem", 3.0f, 5.0f);
    }
    private void Update()
    {
        bool[] difCheck = { true, true, true };
        if (FallingObject.instance.speed >= 3f && FallingObject.instance.speed <= 6f && difCheck[0])
        {
            InvokeRepeating("FallingObjectCreat", 0.0f, 1.0f);
            difCheck[0] = false;
        }
        else if (FallingObject.instance.speed >= 6f && FallingObject.instance.speed <= 12f && difCheck[1])
        {
            InvokeRepeating("FallingObjectCreat", 0.0f, 0.5f);
            difCheck[1] = false;
        }
        else if (FallingObject.instance.speed >= 12f && difCheck[2])
        {
            InvokeRepeating("FallingObjectCreat", 0.0f, 0.3f);
            difCheck[2] = false;
        }
    }
    private void FallingObjectCreat()
    {        
        GameObject obj = objectPool.GetPooledObject();      // 풀에서 비활성화된 obj를 받아오기
        if (obj != null)                                    // obj가 null이 아니면
        {
            obj.SetActive(true);                            // obj 활성화
        }
    }

    private void RandomItem()
    {
        // 정수형 데이터를 저장하는 randomNumber변수 선언
        // Random.Range(0, N) => 0부터 N-1 까지 값 중 하나 선택
        // Random.Range(0, 3) => 0, 1, 2 중에서 하나 랜덤 선택
        int randomNumber = Random.Range(0, falling_ItemPrefabs.Length);

        // randomItemPrefab 게임오브젝트 선언
        // 해당 오브젝트에 랜덤하게 정해진 ItemPrefab 데이터 저장
        GameObject randomItemPrefab = falling_ItemPrefabs[randomNumber];

        // 랜덤하게 정해진 아이템 프리팹을 생성
        Instantiate(randomItemPrefab);
    }
}
