using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_Balloon : Disruptor
{
    // ǳ��(������)�� ȭ��Ʒ����� ���� �������� �÷��̾��� �þ߸� �����ϴ� ���ر���Դϴ�.
    // ǳ���� Order In Layer�� ���� ������ UI�� ������ ��� ���� �����ϴ�.

    // ������Ʈ�� �Ʒ��� �������Ѽ� ���� �ö󰡴°� �ִϸ��̼����� �����
    private GameObject ballooncenter; 
    private Animator animator;

    //Vector2 balloonPos = Vector2.zero;
    private static readonly int IsActive = Animator.StringToHash("IsActive");

    private bool IsExecute = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Transform firstChildTransform = transform.GetChild(0);  // ���̾��Ű ���� ����
        ballooncenter = firstChildTransform.gameObject;
        //balloonPos = ballooncenter.transform.position;
    }
    
    

   
    public override void Execute()
    {
        if (IsExecute) return;  // Balloon�� �۵� ���� �� �� ȣ����� �ʵ��� �ϴ� ����ó��
        IsExecute = true;

        // GameObject Ȱ��ȭ �� Animation ���, ����� ������ GameObject ��Ȱ��ȭ
        ballooncenter.SetActive(true);
        animator.SetBool(IsActive, true);        
    }

    public void DisableForAnimation()   // Animation Clip���� ȣ��Ǵ� �޼���
    {
        //ballooncenter.transform.position = balloonPos;  // �ö� ǳ��������Ʈ�� ���ڸ��� �ǵ���
        animator.SetBool(IsActive, false);
        ballooncenter.SetActive(false);
        IsExecute = false;
    }
    // ������ �ִ� ���� : "BalloonCenter" gameObject�� �Ʒ��� �ǵ��ƿ��� ���� Execute�� ȣ���ϸ� ���峲. gameObject�� �ö��ڸ����� Ȱ��ȭ�Ǿ� ��� ��������.
    
}
