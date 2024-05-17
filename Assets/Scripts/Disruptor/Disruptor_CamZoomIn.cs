using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_Camera : Disruptor
{
    // �÷��̾ �߽����� ī�޶��� �þ߸� ������ ���ع��Դϴ�.

    [SerializeField] private Disruptor disruptor;
    [SerializeField] private GameObject player;
    private Camera _mainCamera;

    [SerializeField, Range(0.5f, 3f)] private float duration = 1f;
    [SerializeField, Range(0.5f, 3f)] private float sightSize = 2.5f;
    //private IEnumerator m_Coroutine;

    private void Awake()
    {
        _mainCamera = disruptor.GetmainCamera();
    }


    public override void Execute()
    {
        StartCoroutine(CoroutineMethod());
    }

    IEnumerator CoroutineMethod()
    {
        ChanegeCameraPosition(player);
        ChangeCameraSize();
        
        yield return new WaitForSeconds(duration);
        _mainCamera.orthographicSize = 5f;
        _mainCamera.transform.position = new Vector3(0, 0, -10f);
    }

    public void ChangeCameraSize()
    {
        // default mainCamera.orthographicSize = 5f
        _mainCamera.orthographicSize = sightSize;
    }

    public void ChanegeCameraPosition(GameObject player)    // TODO :: �Ű����� �ڷ����� �÷��̾ �����Ѱɷ� �ٲٸ� ������
    {
        _mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+2.4f, -10f);
    }

}
