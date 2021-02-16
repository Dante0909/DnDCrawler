using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePathState :State 
{
    public event EventHandler OnChoosePathStateEnter;
    public event EventHandler OnChoosePathStateExit;


    public override void Enter()
    {
        //enable path panel generate random room
    }




    public override void Exit()
    {
       //Disable path panel 
    }
}
