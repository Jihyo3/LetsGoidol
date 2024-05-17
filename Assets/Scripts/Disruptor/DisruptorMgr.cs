using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptorMgr : MonoBehaviour
{
    // DisruptorMgr������ �ٸ� Ŭ������� Disruptor�� �ҷ����� ���� â��

    // ȣ���� ���ع�

    [SerializeField] private GameObject _disruptor_kotori; // ����Ƽ���� �巡�׾ص��ĳ���ϱ�

    private Disruptor disruptor;    // 

    private void Awake()
    {
        disruptor = GetComponent<Disruptor>();
        disruptor.InitDisruptor();
    }

    public void CallDisruptor()
    {
        _disruptor_kotori.SetActive(true);
    }

    // ������ ���ع� �θ���
    // 
    public void CallRandomDisruptor()
    {

    }


}
