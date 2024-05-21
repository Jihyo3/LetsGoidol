using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MissileStation : MonoBehaviour
{
    // 얻은 미사일을 관리하는 클래스. 미사일 puch, 미사일pop
    // 5개짜리 리스트
    Stack<Missile> missileStation = new Stack<Missile>();
    [SerializeField] private Missile obj;
    int maxMissile = 5;

    private void Awake()
    {
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            if (!missileStation.Contains(obj)) { return; }
            missileStation.Pop().Launch();
        }
    }

    public void PushMissile()
    {
        missileStation.Push(obj);
    }

    public void PopMissile()
    {
        missileStation.Pop();
    }

    public void DebugPushPushMissile()
    {
        for (int i = 0; i < 5;  i++)
        {
            missileStation.Push(obj);
        }
        missileStation.Pop().Launch();
    }
}
