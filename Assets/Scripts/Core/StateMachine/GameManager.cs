using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    //We can use a fsm to manage the game states to optimize the code

    public static GameManager instance = null;

    //States
    public GameStates gameState;
    public CombatState combatState = new CombatState();
    public PauseState pauseState = new PauseState();
    public DialogueState dialogueState = new DialogueState();
    public GameStates unPauseStates = new GameStates();


    //Selection
    public LivingEntities selectedEntity;

    
   


    private void Awake()
    {
      
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        gameState = combatState;
    }

    // Update is called once per frame
    void Update()
    {
        gameState = (GameStates)gameState.Process();
    
    }

    public void PauseGame()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameState.TransitionToPauseState();
        }
    }

    public void UnPauseGame()
    {
        pauseState.UnPause();
    }
}
