using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    private float time = 0f;
    private void Awake()
    {
        score = GetComponent<Text>();
    }

    private void Update()
    {

        time += Time.deltaTime;
        score.text = time.ToString("N2");
    }
}
