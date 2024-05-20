using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float speed = 3f;    // ���� �ӵ�

    // ������Ʈ�� Ȱ��ȭ�� �� ȣ��Ǵ� �޼��� : OnEnable
    private void OnEnable()
    {
        // Ȱ��ȭ�� ������ ��ġ�� �缳���մϴ�.
        ResetPosition();
    }
    
    private void ResetPosition()    // ������Ʈ ��ġ ����
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
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    // �ݶ��̴��� isTrigger üũ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ��ü�� �±װ� Ground �̸�
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("�ٴڿ� �浹");
            // ������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
}
