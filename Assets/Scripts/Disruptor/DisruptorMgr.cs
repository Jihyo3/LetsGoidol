using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptorMgr : MonoBehaviour
{
    // DisruptorMgr������ �ٸ� Ŭ������� Disruptor�� �ҷ����� ���� â��

    // ȣ���� ���ع�

    [SerializeField] private GameObject _disruptor; // ����Ƽ���� �巡�׾ص��ĳ���ϱ�

    private Disruptor disruptor;    // 

    

    public void CallDisruptor()
    {
        _disruptor.SetActive(true);        

    }




}
