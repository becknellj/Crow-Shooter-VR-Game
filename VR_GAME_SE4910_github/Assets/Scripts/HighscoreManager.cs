using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
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
        
        connectionString = "URI=file:" + Application.dataPath + "/HighScoresDB.sqlite";
        Debug.Log(connectionString);
        
        showScores();

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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

    private void insertScore(int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                Debug.Log("hi3");

                string sqlQuery = "INSERT INTO HighScoresDB(Score) VALUES("+newScore+")";
               Debug.Log(newScore);
  
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();

                dbConnection.Close();
                Debug.Log("hi7");


            }

        }
    }
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
                    Debug.Log("hi back");
                    reader.Close();
                    dbConnection.Close();

                }
            }

        }
        highScores.Sort();
    }
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
