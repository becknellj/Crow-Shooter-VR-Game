using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Dinesh Punni tutorial

public class GameManager : MonoBehaviour
{
    //event listener for the reset button on the game over canvas
    public static Action OnRestart;

    //canvas that appears when we die
    public GameObject GameOverCanvas;
    public GameObject Enemy;

    //linking the players death to the game over functionality
    private void OnEnable()
    {
        PlayerController.OnPlayerDied += GameOver;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= GameOver;

    }
    
    //makes panel appear and gets rid of the crow in the scene
    void GameOver()
    {
        //enable the gameover canvas
        GameOverCanvas.SetActive(true);
        Enemy.SetActive(false);
    }
    public void Restart()
    {
        //disable game over canvas on restart
        GameOverCanvas.SetActive(false);
        Enemy.GetComponent<EnemyController>().TeleportEnemy();
        Enemy.SetActive(true);

        //called from the button script
        if (OnRestart!=null)
        {
            Debug.Log("RESET GAME");

            OnRestart();
            
        }
    }

}
