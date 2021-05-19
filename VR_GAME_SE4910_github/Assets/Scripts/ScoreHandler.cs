using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//dinesh punni tutorial, partial

//update textmesh as you play the game, keeps track of score
//if I had more time, this is probably where I would have to keep track of the end score to add to database
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
        current_score = 0;
        current_score_text.text = current_score.ToString();

    }

}
