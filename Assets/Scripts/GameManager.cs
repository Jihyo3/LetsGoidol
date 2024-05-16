using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 인스턴스할 프리팹을 저장할 변수
    public GameObject fallingObject;

    void Awake()
    {
        // 프레임 제한
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        // 메서드 반복 호출 키워드 ( FallingObject / 0.0f초 딜레이 / 1.0f초 반복 )
        InvokeRepeating("FallingObject", 0.0f, 1.0f);
    }

    void FallingObject()
    {
        // 오브젝트생성 키워드 ( fallingObject )
        Instantiate(fallingObject);
    }
}
