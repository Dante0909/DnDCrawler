using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //We can use a fsm to manage the game states to optimize the code

    public static GameManager instance = null;

    //States
    public State gameState;
    public CombatState combatState = new CombatState();
    public PauseState pauseState = new PauseState();
    public ChoosePathState choosePathState = new ChoosePathState();


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
        gameState=gameState.Process();
    }
}
