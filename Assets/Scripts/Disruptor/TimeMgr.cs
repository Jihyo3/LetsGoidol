using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TimeMgr : MonoBehaviour
{
    // Test script. �ð� ���࿡ ���� ���ع� �ߵ��� ������ Ŭ����

    [SerializeField] private TMP_Text timeTxt;

    private float time = 0f;

    [SerializeField] private float startSecond = 5f;
    [SerializeField] private float intervalSecond = 5f;

    [SerializeField] private bool optionalRepeat = true;

    private void Start()
    {
        if (!optionalRepeat) return;
        InvokeRepeating("Execute_Sencond", startSecond, intervalSecond);  // �÷��� �� startSecond ���� intervalSecond �������� Execute_Sencond()�޼��尡 �ݺ�����
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N1");
    }

    // �ð��� �Ǹ� �ߵ��ϴ� �Լ�
    private void Execute_Sencond()
    {        
        DisruptorMgr.Instance.CallDisruptor_Random();        
    }

    // Ư���� �ð��� �Ǹ� �ߵ��ϴ� �Լ�
    

}
