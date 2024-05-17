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
    // Disruptor_xxx �ʱ�ȭ�Լ��� ���⼭ �θ���.


    protected Camera mainCamera;

    protected float topEdgeWorldPos;
    protected float bottomEdgeWorldPos;
    protected float leftEdgeWorldPos;
    protected float rightEdgeWorldPos;

    
    public void InitDisruptor() // TODO :: ���ӸŴ��� ��� �ϰ������� �ʱ�ȭ�ǵ��� �ϱ�.
    {
        mainCamera = Camera.main;
        GetCameraEdgeToWolrdPos();
    }

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
        rightEdgeWorldPos = topRightWorld.x;
    }

    public float GettopEdgeWorldPos()    {  return topEdgeWorldPos; }
    public float GetbottomEdgeWorldPos() {  return bottomEdgeWorldPos; }
    public float GetleftEdgeWorldPos() { return leftEdgeWorldPos; }
    public float GetrightEdgeWorldPos() { return rightEdgeWorldPos; }
}