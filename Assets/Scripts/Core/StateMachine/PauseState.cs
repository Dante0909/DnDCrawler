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
       


        base.Enter();
    }


    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        //Disable Pause Panel

        base.Exit();
    }

}
