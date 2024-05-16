using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    float speed = 0.05f;    // ���� �ӵ�

    void Start()
    {
        // x ��ǥ�� ( -3 ~ 3 ) ���� ���� ����
        float x = Random.Range(-3.0f, 3.0f);
        // y ��ǥ�� 5�� ����
        float y = 5.0f;
        // ���� ������Ʈ�� tranform ��ǥ�� x, y �ֱ�
        transform.position = new Vector2(x, y);
    }

    void Update()
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
