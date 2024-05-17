using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 인스턴스할 프리팹을 저장할 변수
    public GameObject fallingObject;

    // 배열로 아이템 프리팹을 저장할 변수
    // GameManager 인스펙터 창에서 증가 감소 가능
    public GameObject[] falling_ItemPrefabs;

    private void Awake()
    {
        // 프레임 60으로 제한
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        // 메서드 반복 호출 키워드 ( FallingObject / 0.0f초 딜레이 / 1.0f초 반복 )
        InvokeRepeating("FallingObject", 0.0f, 1.0f);

        // RandomItem 메서드를 호출 / 게임 시작 3초 뒤에 랜덤 아이템 생성 / 5초마다 랜덤 아이템 생성
        // 아이템의 크기 or 첫 생성 시간을 조절하여 오브젝트가 겹치지 않게 할 수 있습니다.
        InvokeRepeating("RandomItem", 3.0f, 5.0f);
    }

    private void FallingObject()
    {
        // 오브젝트생성 키워드 ( fallingObject )
        Instantiate(fallingObject);
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
