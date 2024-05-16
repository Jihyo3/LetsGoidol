using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor : MonoBehaviour
{
    // Disruptor�� ������ ���ع����ӿ�����Ʈ�� �۵��� �����ϴ� Ŭ�����Դϴ�.

    [SerializeField] SpriteRenderer spriteRenderer;

    private FourEdge[] fourEdges;

    

    public Disruptor()
    {
        fourEdges = new FourEdge[4];
        fourEdges[0] = new FourEdge(-4.11f, -0.2f, false, false);
        fourEdges[1] = new FourEdge(4.07f, -0.2f, true, false);
        fourEdges[2] = new FourEdge(4.07f, 0.2f, true, true);
        fourEdges[3] = new FourEdge(-4.11f, 0.2f, false, true);
    }


    private IEnumerator m_Coroutine;

    void OnEnable()
    {
        int i = Random.Range(0, 4);
        NewPos(fourEdges[i]);
        m_Coroutine = CoroutineMethod();
        StartCoroutine(m_Coroutine); // �ڷ�ƾ�� �����ϴ� �Լ�       
    }

    IEnumerator CoroutineMethod()
    {
        
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    // �迭�� ������ ��ǥ�� flip�� ����ֱ�

    void NewPos(FourEdge _four)
    {
        //int screenWidth = Screen.width;
        //int screenHeight = Screen.height;
        gameObject.transform.position = new Vector2(_four.Getx(), _four.Gety());
        spriteRenderer.flipX = _four.IsFlipX();
        spriteRenderer.flipY = _four.IsFlipY();

    }


    void CallDisruptor1()   // ���丮
    {
        // ȭ�� �ػ󵵰� �ٲ���� �������� �����ǵ��� �ϱ�.
        // ��ũ�� ���ϱ�
        

        // ������Ʈ Ȱ��ȭ
        gameObject.SetActive(true);
    }


    void Disrupt1()
    {

    }

}

public class FourEdge
{
    private float x;
    private float y;
    private bool flipX;
    private bool flipY;

    public FourEdge(float _x, float _y, bool _flipX, bool _flipY)
    {
        x = _x;
        y = _y;
        flipX = _flipX;
        flipY = _flipY;
    }

    public float Getx()
    {
        return x;
    }
    public float Gety()
    {
        return y;
    }
    public bool IsFlipX()
    {
        return flipX;
    }
    public bool IsFlipY()
    {
        return flipY;
    }

}