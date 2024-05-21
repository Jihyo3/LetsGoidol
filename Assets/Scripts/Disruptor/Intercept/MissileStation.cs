using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MissileStation : MonoBehaviour
{
    // 얻은 미사일을 관리하는 클래스. 미사일 puch, 미사일pop
    // 5개짜리 리스트
    Stack<GameObject> missileStation = new Stack<GameObject>();
    GameObject obj;
    int maxMissile = 5;

    private void Awake()
    {
        
    }


    void PushMissile()
    {
        missileStation.Push(obj);
    }

    void PopMissile()
    {
        missileStation.Pop();
    }
}

public class LaunchBtn : MonoBehaviour
{

}

public class Missile : MonoBehaviour
{
    // 미사일의 성격 작동 발사 착탄
    float speed;
    Ladar ladar;

    Rigidbody2D rb;
   
    Vector2 direction;
    string targetLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Launch(Vector2 direction)
    {
        // 방향
        rb.velocity = direction * speed;
    }

    void Hit()
    {
        // 충돌하면 미사일에 맞는 효과를 발생시킴. 이는 자식클래스에서 효과를 구현.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask collisionLayer = LayerMask.NameToLayer(targetLayer);
        if( collisionLayer == ( collisionLayer | (1 << collision.gameObject.layer ) ) )
        {
            Hit();
        }

    }

}

public class Ladar : MonoBehaviour
{
    // 주변탐색, 가까운 오브젝트 판단을 담당하는 클래스

    Vector2 originPos;  // 탐색 원점
    float searchRadius;
    int targetLayerMask;

    // 원점 _originPos와 _searchRadius의 반지름을 가진 원의 범위에서 _targetLayerMask를 가진 GameObject를 반환하는 메서드.
    GameObject SearchClosestColliderInCircle(Vector2 _originPos, float _searchRadius, int _targetLayerMask)
    {
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;
                
        Collider2D[] searchColliders = Physics2D.OverlapCircleAll(_originPos, _searchRadius, _targetLayerMask);

        // 검색된 searchColliders의 거리 계산
        foreach(Collider2D collider in searchColliders)
        {
            float distance = Vector2.Distance(originPos, collider.transform.position);
            if ( distance < closestDistance ) 
            {
                closestDistance = distance;
                closestObject = collider.gameObject;
            }
        }
        return closestObject;
    }

    Vector2 GetDirection(Vector2 _targetPos, Vector2 _originPos)
    {
        Vector2 direction_originTo_target = (_targetPos - _originPos).normalized;       
        return direction_originTo_target;
    }


    // 원형 범위를 시각적으로 확인하기 위해 Gizmos 사용
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}

public class Intercept_Missile : Missile
{
    // 요격미사일의 작동을 구현


}