using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameStates
{
    public event EventHandler OnGameOverStateTurnEnter;
    public event EventHandler OnGameOverStateTurnExit;


    public override void Enter()
    {
        OnGameOverStateTurnEnter?.Invoke(this, EventArgs.Empty);
        base.Enter();
    }




    public override void Exit()
    {
        OnGameOverStateTurnExit?.Invoke(this, EventArgs.Empty);
        base.Exit();
    }
}
