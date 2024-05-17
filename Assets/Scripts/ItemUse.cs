using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject shield;
    float itemTime = 5f;

    private void Awake()
    {
        player = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if(itemTime == 0f)
        {
            itemTime = 5.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SizeUpItem"))
        {
            player.localScale = new Vector3(1.5f,1.5f,1);
            itemTime -= Time.deltaTime;
        }

        if (collision.CompareTag("Shield"))
        {
            shield.SetActive(true);
            itemTime -= Time.deltaTime;
        }

        if (collision.CompareTag("Unknow"))
        {

        }
    }
}
