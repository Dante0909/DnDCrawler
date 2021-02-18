using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    [SerializeField]private GameObject PausePanel;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        
        if (gameManager != null)
        {
            gameManager.pauseState.OnPauseStateTurnEnter +=PauseUIOnStart ;
            gameManager.pauseState.OnPauseStateTurnExit += PauseUIOnEnd;
        }
    }
    private void PauseGame()
    {
      
        PausePanel.SetActive(true);
    }

    private void UnPauseGame()
    {
        PausePanel.SetActive(false);
    }
    private void PauseUIOnStart(object sender, System.EventArgs e)
    {
        PauseGame();
    }
    private void PauseUIOnEnd(object sender, System.EventArgs e)
    {
        UnPauseGame();
    }



}
