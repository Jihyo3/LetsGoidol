using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MissileStation : MonoBehaviour
{
    // 얻은 미사일을 관리하는 클래스. 미사일 puch, 미사일pop
    // 5개짜리 리스트
    Stack<Missile> missileStation = new Stack<Missile>();
    [SerializeField] private Missile prefab;
    int maxMissile = 5;


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.M))
        {
            if (!missileStation.Contains(prefab)) { return; }
            missileStation.Pop().Launch();
        }
    }

    public void PushMissile()
    {
        missileStation.Push(prefab);
    }

    public void PopMissile()
    {
        missileStation.Pop();
    }

    public void DebugPushPushMissile()
    {
        
            MakeMissile();
        
        missileStation.Pop().Launch();
    }

    // 이벤트가 작동하면 미사일을 생성하는 함수
    public void MakeMissile()
    {
        missileStation.Push(Instantiate(prefab, transform));
    }
}
