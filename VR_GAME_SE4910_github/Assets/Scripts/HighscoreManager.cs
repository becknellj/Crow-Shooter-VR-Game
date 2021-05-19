using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
//iScore Studios tutorial
//my database only included one table with 2 columns, player ID and score

//ran out of time to connect these scripts to the other ui element that keeps track of the current score
//needed to add that value into the database on game over
public class HighscoreManager : MonoBehaviour
{
    private string connectionString;
    private List<HighScore> highScores = new List<HighScore>();
    public GameObject scorePrefab;
    public Transform scoreParent;
    public int topRanks;

    // Start is called before the first frame update
    void Start()
    {
        //path for database connection
        connectionString = "URI=file:" + Application.dataPath + "/HighScoresDB.sqlite";
        Debug.Log(connectionString);
        
        showScores();

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //if we want to delet a score, will come in handy when we dont want to keep
    //track of anything buit the top n scores
    private void deleteScore(int id)
    {
       using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            Debug.Log("hi");

            dbConnection.Open();
            Debug.Log("hi");

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("DELETE FROM HighScoresDB WHERE PlayerId = \"{0}\"", id);
                
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }

        }

    }
    //to insert a score into the table
    private void insertScore(int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                Debug.Log("hi3");

               //originally had string format but forgot to change it back
               //creates a query to add the score to the table
               string sqlQuery = "INSERT INTO HighScoresDB(Score) VALUES("+newScore+")";
               Debug.Log(newScore);
                
                //connects the command and executes, adding the new score to teh table
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                dbConnection.Close();


            }

        }
    }
    
    //provides a soreted list of all scores in the database from greatest to least
    private void getScores()
    {
        //clears out any previously saved scores
        highScores.Clear();
 
        //connection to the database by using global connection string
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScoresDB";
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        //adding hihgscores to the list
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(1)));
                    }
                   
                    reader.Close();
                    dbConnection.Close();

                }
            }

        }
        //calls the icomparable sorting compareTo in highscores.cs
        highScores.Sort();
    }
    //updates the UI by calling setScore in the HighscoreScript.cs
    private void showScores()
    {
        getScores();
        for (int i = 0; i < topRanks; i++)
        {
            if (i <= highScores.Count-1)
            {
                GameObject tempObject = Instantiate(scorePrefab);
                HighScore tempScore = highScores[i];

                tempObject.transform.SetParent(scoreParent);
                tempObject.GetComponent<HighScoreScript>().setScore("#" + (i + 1).ToString(), tempScore.Score.ToString());
            }
          
            
        }
        
    }
}
