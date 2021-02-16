using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //We can use a fsm to manage the game states to optimize the code

    public static GameManager instance = null;

    //States
    public State gameState;
    public CombatState combatState = new CombatState();
    public PauseState pauseState = new PauseState();
    public ChoosePathState choosePathState = new ChoosePathState();



    private void Awake()
    {
      

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


       
    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameState=gameState.Process();
    }
}
