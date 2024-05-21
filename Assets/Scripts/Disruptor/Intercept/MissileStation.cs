using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MissileStation : MonoBehaviour
{
    // ���� �̻����� �����ϴ� Ŭ����. �̻��� puch, �̻���pop
    // 5��¥�� ����Ʈ
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
    // �̻����� ���� �۵� �߻� ��ź
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
        // ����
        rb.velocity = direction * speed;
    }

    void Hit()
    {
        // �浹�ϸ� �̻��Ͽ� �´� ȿ���� �߻���Ŵ. �̴� �ڽ�Ŭ�������� ȿ���� ����.
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
    // �ֺ�Ž��, ����� ������Ʈ �Ǵ��� ����ϴ� Ŭ����

    Vector2 originPos;  // Ž�� ����
    float searchRadius;
    int targetLayerMask;

    // ���� _originPos�� _searchRadius�� �������� ���� ���� �������� _targetLayerMask�� ���� GameObject�� ��ȯ�ϴ� �޼���.
    GameObject SearchClosestColliderInCircle(Vector2 _originPos, float _searchRadius, int _targetLayerMask)
    {
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;
                
        Collider2D[] searchColliders = Physics2D.OverlapCircleAll(_originPos, _searchRadius, _targetLayerMask);

        // �˻��� searchColliders�� �Ÿ� ���
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


    // ���� ������ �ð������� Ȯ���ϱ� ���� Gizmos ���
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}

public class Intercept_Missile : Missile
{
    // ��ݹ̻����� �۵��� ����


}