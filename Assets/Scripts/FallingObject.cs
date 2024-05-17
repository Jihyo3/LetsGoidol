using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private float speed = 0.05f;    // ���� �ӵ�

    private void Start()
    {
        // x ��ǥ�� ( -8 ~ 8 ) ���� ���� ����
        float x = Random.Range(-8.0f, 8.0f);
        // y ��ǥ�� 5�� ����
        float y = 5.0f;
        // ���� ������Ʈ�� tranform ��ǥ�� x, y �ֱ�
        transform.position = new Vector2(x, y);
    }

    private void Update()
    {
        // ���� ������Ʈ�� �Ʒ��� speed ��ŭ �̵�
        transform.position += Vector3.down * speed;
    }

    // �ݶ��̴��� isTrigger üũ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��ü�� �±װ� Ground �̸�
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("�浹");
            // ���� ������Ʈ ����
            Destroy(this.gameObject);
        }
    }
}