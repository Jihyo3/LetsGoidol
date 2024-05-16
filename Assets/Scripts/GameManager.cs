using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �ν��Ͻ��� �������� ������ ����
    public GameObject fallingObject;

    void Awake()
    {
        // ������ ����
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        // �޼��� �ݺ� ȣ�� Ű���� ( FallingObject / 0.0f�� ������ / 1.0f�� �ݺ� )
        InvokeRepeating("FallingObject", 0.0f, 1.0f);
    }

    void FallingObject()
    {
        // ������Ʈ���� Ű���� ( fallingObject )
        Instantiate(fallingObject);
    }
}
