using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        if(gameManager != null)
        {
            gameManager.gameOverState.OnGameOverStateTurnEnter += GameOverUIOnStart;
            gameManager.gameOverState.OnGameOverStateTurnExit += GameOverUIOnEnd;

        }
    }
    private void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    private void GameOverUIOnStart(object sender, System.EventArgs e)
    {
        GameOver();
    }
    private void GameOverUIOnEnd(object sender, System.EventArgs e)
    {

    }
}
