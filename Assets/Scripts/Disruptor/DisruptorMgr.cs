using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisruptorMgr : MonoBehaviour
{
    // DisruptorMgr에서는 다른 클래스등에서 Disruptor를 불러오기 위한 창구

    // 호출할 방해물

    [SerializeField] private GameObject _disruptor; // 유니티에서 드래그앤드롭캐싱하기

    private Disruptor disruptor;    // 

    

    public void CallDisruptor()
    {
        _disruptor.SetActive(true);        

    }




}
