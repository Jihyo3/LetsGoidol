using Unity.VisualScripting;
using UnityEngine;

public class Intercept_Missile : Missile
{
    // 요격미사일의 작동을 구현
    // SO를 활용하면 좋겠다.
    private GameObject player;
    Ladar ladar;
    Rigidbody2D rb;

    Vector2 direction;

    private LayerMask targetLayer;  //LayerMask는 이진수비트다.
 
    [SerializeField] private float range = 500f;
    [SerializeField] private float speed = 20f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ladar = transform.parent.GetComponent<Ladar>();
        player = transform.root.gameObject;
    }

    private void Start()
    {
        targetLayer = LayerMask.NameToLayer("FallingObject");
    }

    public override void Launch()
    {
        GetTarget();
        rb.velocity = direction * speed;
    }

    protected override void GetTarget()
    {
        Vector2 playerPos = player.transform.position;
        GameObject target = ladar.SearchClosestColliderInCircle(playerPos, range, targetLayer); //  1 <<6
        direction = ladar.GetDirection(target.transform.position, playerPos);
    }

    void Hit(Collision2D collision)
    {
        // 충돌하면 미사일에 맞는 효과를 발생시킴. 이는 자식클래스에서 효과를 구현.
        collision.gameObject.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask collisionLayer = targetLayer;
        if (collisionLayer == (collisionLayer | (1 << collision.gameObject.layer)))
        {
            Hit(collision);
        }
    }
}
