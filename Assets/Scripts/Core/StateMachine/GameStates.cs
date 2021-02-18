using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : State
{
    //This will just contain the transition functions for the state machine 

    GameManager manager = GameManager.instance;

    //Could condense it down to 1 method that you pass the state but fuck it easier to read
    private void TransitionShell(GameStates state)
    {
        nextState = state;
        GameManager.instance.gameState.phase = Phase.EXIT;
        state.phase = Phase.ENTER;
    }
   public void TransitionToCombatState()
    {
        TransitionShell(GameManager.instance.combatState);
    }
    public void  TransitionToPauseState()
    {

        GameManager.instance.unPauseStates = GameManager.instance.gameState;
        MonoBehaviour.print(GameManager.instance.gameState);
        MonoBehaviour.print(GameManager.instance.unPauseStates);
        nextState = GameManager.instance.pauseState;
       
        GameManager.instance.pauseState.phase = Phase.ENTER;
        GameManager.instance.gameState.phase = Phase.EXIT;

    }
    public void UnPause()
    {
        MonoBehaviour.print(GameManager.instance.unPauseStates);
        nextState = GameManager.instance.unPauseStates;
        GameManager.instance.gameState.phase = Phase.EXIT;
        GameManager.instance.unPauseStates.phase = Phase.ENTER;
    }
    public void TransitionToChoosePathState()
    {
        TransitionShell(GameManager.instance.dialogueState);
    }


}
