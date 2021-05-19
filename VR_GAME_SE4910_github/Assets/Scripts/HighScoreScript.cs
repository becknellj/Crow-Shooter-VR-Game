using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//iScore Studios tutorial

public class HighScoreScript : MonoBehaviour
{
    public TextMeshPro score;
    public TextMeshPro rank;

    //sets the UI to the high score values
    public void setScore(string rank1, string score)
    {
        //setting the visual text
        this.rank.SetText(rank1);
        this.score.SetText(score);
    }
}
