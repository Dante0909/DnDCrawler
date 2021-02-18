using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : GameStates
{
    public event EventHandler OnPauseStateTurnEnter;
    public event EventHandler OnPauseStateTurnExit;


    public override void Enter()
    {
        OnPauseStateTurnEnter?.Invoke(this, EventArgs.Empty);
        base.Enter();
    }


  

    public override void Exit()
    {
        OnPauseStateTurnExit?.Invoke(this, EventArgs.Empty);
        base.Exit();
    }

}
