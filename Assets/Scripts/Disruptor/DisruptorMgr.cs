using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptorMgr : MonoBehaviour
{
    // DisruptorMgr������ �ٸ� Ŭ������� Disruptor�� �ҷ����� ���� â�������� �ϴ� Ŭ�����Դϴ�.

    public static DisruptorMgr Instance;

    List<Disruptor> _disruptorList;


    // ȣ���� ���ع�

    [SerializeField] private Disruptor _disruptor_kotori; // ����Ƽ���� �巡�׾ص��ĳ���ϱ�
    [SerializeField] private Disruptor _disruptor_Camera;
    [SerializeField] private Disruptor _disruptor_Cam180;
    [SerializeField] private Disruptor _disruptor_Balloon;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (_disruptorList == null)
        {
            _disruptorList = new List<Disruptor>
            {
                _disruptor_kotori,
                _disruptor_Camera,
                _disruptor_Cam180,
                _disruptor_Balloon
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
    public void CallDisruptor_Cam180()
    {
        _disruptor_Cam180.Execute();
    }
    public void CallDisruptor_Balloon()
    {
        _disruptor_Balloon.Execute();
    }

    // ������ ���ع� �θ���
    public void CallDisruptor_Random()
    {
        int i = Random.Range(0, _disruptorList.Count);
        _disruptorList[i].Execute();
    }

}