using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GetComponent<Transform>();
        UseItem(5f);
    }

    private void UseItem(float itemUseTime)
    {
        if (itemUseTime > 0f)
        {
           player.transform.localScale = new Vector3(1.5f,1.5f,1);
           itemUseTime -= Time.deltaTime;
        }
        else
        {
            player.transform.localScale = new Vector3(1f, 1f, 1);
        }
    }
}
