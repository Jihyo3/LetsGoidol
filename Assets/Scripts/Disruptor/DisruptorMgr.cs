using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptorMgr : MonoBehaviour
{
    // DisruptorMgr������ �ٸ� Ŭ������� Disruptor�� �ҷ����� ���� â��

    // ȣ���� ���ع�

    [SerializeField] private Disruptor_Kotori _disruptor_kotori; // ����Ƽ���� �巡�׾ص��ĳ���ϱ�
    [SerializeField] private Disruptor_Camera _disruptor_Camera;
    

    private void Awake()
    {
       
    }

    public void CallDisruptor_kotori()
    {
        _disruptor_kotori.Execute();
    }

    public void CallDisruptor_camera()
    {
        _disruptor_Camera.Execute();
    }

    // ������ ���ع� �θ���
    // 
    public void CallRandomDisruptor()
    {

    }


}
