using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_Kotori : Disruptor
{
    // 플레이 스크린 구석에서 랜덤하게 등장하여 화면을 가리는 방해물입니다.
    private SpriteRenderer spriteRenderer;

    private FourEdge[] fourEdges;
    
    [SerializeField, Range(0.5f, 3f)] private float _popuptime = 1f;
       

    private IEnumerator m_Coroutine;

    private void Awake()
    {        
        spriteRenderer = GetComponent<SpriteRenderer>();
        

        

        //fourEdges[0] = new FourEdge(-4.11f, -0.2f, false, false);
        //fourEdges[1] = new FourEdge(4.07f, -0.2f, true, false);
        //fourEdges[2] = new FourEdge(4.07f, 0.2f, true, true);
        //fourEdges[3] = new FourEdge(-4.11f, 0.2f, false, true);
    }

    void OnEnable()
    {
        if(fourEdges == null)
        {
            fourEdges = new FourEdge[4];
            fourEdges[0] = new FourEdge(leftEdgeWorldPos, bottomEdgeWorldPos, false, false);
            fourEdges[1] = new FourEdge(rightEdgeWorldPos, bottomEdgeWorldPos, true, false);
            fourEdges[2] = new FourEdge(rightEdgeWorldPos, topEdgeWorldPos, true, true);
            fourEdges[3] = new FourEdge(leftEdgeWorldPos, topEdgeWorldPos, false, true);
        }
        int i = Random.Range(0, 4);
        NewPos(fourEdges[i]);
        m_Coroutine = CoroutineMethod();
        StartCoroutine(m_Coroutine);
    }

    IEnumerator CoroutineMethod()
    {
        yield return new WaitForSeconds(_popuptime);
        gameObject.SetActive(false);
    }


    void NewPos(FourEdge _four)
    {
        gameObject.transform.position = new Vector2(_four.Getx(), _four.Gety());
        spriteRenderer.flipX = _four.IsFlipX();
        spriteRenderer.flipY = _four.IsFlipY();
    }

    private class FourEdge
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
}


// 화면 구석을 알아서 찾아가게 변수화 하고싶다.