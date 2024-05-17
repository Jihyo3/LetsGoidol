using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Prac_Collider : MonoBehaviour
{
    // 게임오브젝트간 충돌의 판단과 충돌에 따른 실행을 담당하는 클래스 입니다.

    [SerializeField] private GameObject player; // 플레이어를 캐싱할 자리. 없어도 될지도.




    // 이 스크립트의 gameObject와 매개변수collision이 부딪히면 실행되는 메서드
    private void OnCollisionEnter2D(Collision2D collision)  
    {
        GameObject collisionObj = collision.gameObject;

        // CompareTag를 이용해 충돌비교
        if (collisionObj.CompareTag("FallingObject"))
        {
            // 플레이어 오브젝트가 추락물과 맞으면 게임오버

        }

        // 방해물 오브젝트와 부딪힌다면
        if (collisionObj.CompareTag("Disruptor"))
        {
            DisruptorMgr.Instance.CallDisruptor_Random();
        }


    }


    // 일정 시간이 된다면 이벤트가 발동하는 함수

    public event Action<float> OnTimeEvent;
    float time;

    public void CallTimeEvent(float _time)
    {
        OnTimeEvent?.Invoke(_time);
    }

    private void Update()
    {
        CallTimeEvent(time);
    }

    private void Startttt()
    {
        OnTimeEvent += DoTimeEvent;
    }
    
    private void DoTimeEvent(float _time)
    {
        float i = _time / 10;
        if (i >= 1f)   
        {
            DisruptorMgr.Instance.CallDisruptor_Random();
            i--;
        }
    }




}
