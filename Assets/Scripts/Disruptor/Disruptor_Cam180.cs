using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disruptor_Cam180 : Disruptor
{
    [SerializeField] private Camera _mainCamera;
    
    [SerializeField, Range(0.5f, 3f)] private float duration = 1.5f;
    

    private void Start()
    {
        
    }


    public override void Execute()
    {
        StartCoroutine(CoroutineMethod());
    }

    IEnumerator CoroutineMethod()
    {

        ChangeCameraRotation();
        yield return new WaitForSeconds(duration);
        _mainCamera.transform.Rotate(0, 0, 180f);
    }

    public void ChangeCameraRotation()
    {
        _mainCamera.transform.Rotate(0,0,180f);
    }


}