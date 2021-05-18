using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//must implement the interface to sort the high scores
class HighScore : IComparable<HighScore>
{
    public int Score { get; set; }
    public int ID { get; set; }
    
    public HighScore (int id, int score)
    {
        this.Score = score;
        this.ID = id;
    }

    //used when we call sort on highscore list
    public int CompareTo(HighScore other)
    {
        //first == other -> returns 0

        //first > second -> returns -1
        if (other.Score < this.Score)
        {
            return -1;
        }

        //first < second -> returns 1
        else if (other.Score > this.Score)
        {
            return 1;
        }
       
        return 0;
    }
}
