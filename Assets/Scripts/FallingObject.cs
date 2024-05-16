using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    float speed = 0.05f;    // 낙하 속도

    void Start()
    {
        // x 좌표를 ( -3 ~ 3 ) 사이 랜덤 생성
        float x = Random.Range(-3.0f, 3.0f);
        // y 좌표를 5로 고정
        float y = 5.0f;
        // 현재 오브젝트의 tranform 좌표에 x, y 넣기
        transform.position = new Vector2(x, y);
    }

    void Update()
    {
        // 현재 오브젝트가 아래로 speed 만큼 이동
        transform.position += Vector3.down * speed;
    }

    // 콜라이더의 isTrigger 체크
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 닿은 물체의 태그가 Ground 이면
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("충돌");
            // 현재 오브젝트 제거
            Destroy(this.gameObject);
        }
    }
}
