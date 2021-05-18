using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnRestart;

    public GameObject GameOverCanvas;
    public GameObject Enemy;

    private void OnEnable()
    {
        PlayerController.OnPlayerDied += GameOver;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= GameOver;

    }

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
