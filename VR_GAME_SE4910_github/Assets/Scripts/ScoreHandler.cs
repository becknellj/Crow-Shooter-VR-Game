using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int current_score;
    private int highscore;

    private TextMeshPro current_score_text;
    private TextMeshPro high_score_text;

    void Start()
    {
        current_score_text = GetComponent<TextMeshPro>();
        high_score_text = GetComponent<TextMeshPro>();

    }
    private void OnEnable()
    {
        EnemyController.OnEnemyDied += IncreaseScore ;
        GameManager.OnRestart += ResetScore;
    }
    private void OnDisable()
    {
        EnemyController.OnEnemyDied -= IncreaseScore;

    }
    void IncreaseScore()
    {
        current_score++;
        current_score_text.text = current_score.ToString();
    }
    void ResetScore()
    {
        //check to see if higher than score in database
        /*if (current_score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", current_score);
            high_score_text.text = current_score.ToString();
        }*/
        
        current_score = 0;
        current_score_text.text = current_score.ToString();

    }

}
