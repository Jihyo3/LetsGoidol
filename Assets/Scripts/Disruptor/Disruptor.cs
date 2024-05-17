using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    // Disruptor�� ������ ���ع����ӿ�����Ʈ�� �۵��� �����ϴ� Ŭ�����Դϴ�.
    // Disruptor : ����Ŭ����
    // Disruptor_xxx : �ڽ�Ŭ����
    // �������� ����� ���� Disruptor_xxx�� List�� ���� �� �ְ��ϱ� ����.


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

    // ī�޶��� ����ƮTo���� ��ǥ ����
    // ī�޶� ����ִ� ������ǥ�� ���ϰ� 4������� ������
    // �ۼ��������� 
    // 0,0 1,1
    // ȭ�鿡 ������ �ִ� ������������ ������ ���϶�
    private void GetCameraEdgeToWolrdPos()
    {
        // ȭ���� �� ������ ����Ʈ ��ǥ
        Vector3 bottomLeftViewport = new Vector3(0, 0, 0);
        Vector3 topRightViewport = new Vector3(1, 1, 0);

        // ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 bottomLeftWorld = mainCamera.ViewportToWorldPoint(bottomLeftViewport);
        Vector3 topRightWorld   = mainCamera.ViewportToWorldPoint(topRightViewport);

        // ȭ�� �� ��ǥ�� ����
        topEdgeWorldPos = topRightWorld.y;
        bottomEdgeWorldPos = bottomLeftWorld.y;
        leftEdgeWorldPos = bottomLeftWorld.x;
        rightEdgeWorldPos = topRightWorld.y;
    }

}