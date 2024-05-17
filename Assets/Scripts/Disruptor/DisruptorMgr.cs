using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptorMgr : MonoBehaviour
{
    // DisruptorMgr에서는 다른 클래스등에서 Disruptor를 불러오기 위한 창구

    // 호출할 방해물

    [SerializeField] private Disruptor _disruptor_kotori; // 유니티에서 드래그앤드롭캐싱하기
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

    // 랜덤한 방해물 부르기
    // 
    public void CallDisruptor_Random()
    {
        int i = Random.Range(0, _disruptorList.Count);
        _disruptorList[i].Execute();
    }

}
