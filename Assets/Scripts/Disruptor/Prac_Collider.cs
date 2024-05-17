using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Prac_Collider : MonoBehaviour
{
    // ���ӿ�����Ʈ�� �浹�� �Ǵܰ� �浹�� ���� ������ ����ϴ� Ŭ���� �Դϴ�.

    [SerializeField] private GameObject player; // �÷��̾ ĳ���� �ڸ�. ��� ������.




    // �� ��ũ��Ʈ�� gameObject�� �Ű�����collision�� �ε����� ����Ǵ� �޼���
    private void OnCollisionEnter2D(Collision2D collision)  
    {
        GameObject collisionObj = collision.gameObject;

        // CompareTag�� �̿��� �浹��
        if (collisionObj.CompareTag("FallingObject"))
        {
            // �÷��̾� ������Ʈ�� �߶����� ������ ���ӿ���

        }

        // ���ع� ������Ʈ�� �ε����ٸ�
        if (collisionObj.CompareTag("Disruptor"))
        {
            DisruptorMgr.Instance.CallDisruptor_Random();
        }


    }


    // ���� �ð��� �ȴٸ� �̺�Ʈ�� �ߵ��ϴ� �Լ�

    public event Action<float> OnTimeEvent;
    float time;

    public void CallTimeEvent(float _time)
    {
        OnTimeEvent?.Invoke(_time);
    }

    private void Update()
    {
        CallTimeEvent(time);
    }

    private void Startttt()
    {
        OnTimeEvent += DoTimeEvent;
    }
    
    private void DoTimeEvent(float _time)
    {
        float i = _time / 10;
        if (i >= 1f)   
        {
            DisruptorMgr.Instance.CallDisruptor_Random();
            i--;
        }
    }




}
