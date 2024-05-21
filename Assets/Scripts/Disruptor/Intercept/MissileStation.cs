using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MissileStation : MonoBehaviour
{
    // ���� �̻����� �����ϴ� Ŭ����. �̻��� puch, �̻���pop
    // 5��¥�� ����Ʈ
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
