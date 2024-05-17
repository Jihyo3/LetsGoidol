using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private TMP_Text score;
    private float time = 0f;

    private void Awake()
    {
        score = GetComponent<TMP_Text>();
    }

    private void Update()
    {

        time += Time.deltaTime;
        score.text = time.ToString("N2");
    }
}
