using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 playerPosition = player.transform.position;        
        rb2d.transform.position = playerPosition + new Vector2(0 , 1f);
    }

}
