using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptorMgr : MonoBehaviour
{
    // DisruptorMgr������ �ٸ� Ŭ������� Disruptor�� �ҷ����� ���� â��

    // ȣ���� ���ع�

    [SerializeField] private Disruptor _disruptor_kotori; // ����Ƽ���� �巡�׾ص��ĳ���ϱ�
    [SerializeField] private Disruptor _disruptor_Camera;
    
    List<Disruptor> _disruptorList;

    private void Awake()
    {
        if (_disruptorList == null)
        {
            _disruptorList = new List<Disruptor>
            {
                _disruptor_kotori,
                _disruptor_Camera
            };
        }
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
    public void CallDisruptor_Random()
    {
        int i = Random.Range(0, _disruptorList.Count);
        _disruptorList[i].Execute();
    }

}
