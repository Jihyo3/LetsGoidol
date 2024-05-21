using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    [SerializeField] private Text ScoreNow;
    [SerializeField] private Text ScoreBest;

    void Start()
    {
        float currentScore = ScoreManager.instance.score; // ���� ���ھ� ������ �޾ƿµ� currentScore ���� �����Ѵ�.
        string bestScore = ""; //�ְ� ������ ����صα����� string
        ScoreNow.text = ScoreManager.instance.score.ToString("N2"); // ���� �������� �޾ƿµ� text �� �����Ѵ�.

        if (PlayerPrefs.HasKey(bestScore)) // ���� �÷��̾� �ְ��� ������ ����
        {
            float score = PlayerPrefs.GetFloat(bestScore);

            if (score < currentScore)
            {
                PlayerPrefs.SetFloat(bestScore, currentScore);
                ScoreBest.text = currentScore.ToString("N2");
            }
            else
            {
                ScoreBest.text = score.ToString("N2");
            }
        }
        else // �÷��̾� �ְ��� ������ ����.
        {
            PlayerPrefs.SetFloat(bestScore, currentScore); // ���� ���ھ �ְ��ھ�� �����Ѵ�.
            ScoreBest.text = currentScore.ToString("N2"); // ���罺�ھ �ְ� ���ھ�� ����Ѵ�.
        }
    }

    
}
