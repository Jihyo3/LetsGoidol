using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    // Disruptor는 갖가지 방해물게임오브젝트의 작동을 구현하는 클래스입니다.
    // Disruptor : 상위클래스
    // Disruptor_xxx : 자식클래스
    // 제각각인 기능을 가진 Disruptor_xxx를 List로 담을 수 있게하기 위함.


    protected Camera mainCamera;

    protected float topEdgeWorldPos;
    protected float bottomEdgeWorldPos;
    protected float leftEdgeWorldPos;
    protected float rightEdgeWorldPos;

    
    protected virtual void Awake()
    {
        mainCamera = Camera.main;
        GetCameraEdgeToWolrdPos();
    }

    // 카메라의 뷰포트To월드 좌표 따기
    // 카메라가 찍고있는 월드좌표를 구하고 4등분으로 나눈다
    // 퍼센테이지로 
    // 0,0 1,1
    // 화면에 찍히고 있는 월드포지션의 영역을 구하라
    private void GetCameraEdgeToWolrdPos()
    {
        // 화면의 각 구석의 뷰포트 좌표
        Vector3 bottomLeftViewport = new Vector3(0, 0, 0);
        Vector3 topRightViewport = new Vector3(1, 1, 0);

        // 뷰포트 좌표를 월드 좌표로 변환
        Vector3 bottomLeftWorld = mainCamera.ViewportToWorldPoint(bottomLeftViewport);
        Vector3 topRightWorld   = mainCamera.ViewportToWorldPoint(topRightViewport);

        // 화면 끝 좌표를 구함
        topEdgeWorldPos = topRightWorld.y;
        bottomEdgeWorldPos = bottomLeftWorld.y;
        leftEdgeWorldPos = bottomLeftWorld.x;
        rightEdgeWorldPos = topRightWorld.y;
    }

}