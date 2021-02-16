using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : State
{
    //This will just contain the transition functions for the state machine 

    GameManager manager = GameManager.instance;

    //Could condense it down to 1 method that you pass the state but fuck it easier to read
   public void TransitionToCombatState()
    {
        nextState = manager.combatState;
        phase = Phase.EXIT;
        
    }
    public void  TransitionToPauseState()
    {
        nextState = manager.pauseState;
        phase = Phase.EXIT;
    }
    public void TransitionToChoosePathState()
    {
        nextState = manager.choosePathState;
        phase = Phase.EXIT;
    }


}
