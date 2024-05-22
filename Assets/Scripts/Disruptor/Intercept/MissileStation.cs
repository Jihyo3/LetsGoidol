using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MissileStation : MonoBehaviour
{
    // ���� �̻����� �����ϴ� Ŭ����. �̻��� puch, �̻���pop
    // 5��¥�� ����Ʈ
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

    // �̺�Ʈ�� �۵��ϸ� �̻����� �����ϴ� �Լ�
    public void MakeMissile()
    {
        missileStation.Push(Instantiate(prefab, transform));
    }
}
