using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatState : GameStates
{
    GameManager gameManager;

    //Event handlers work by decoupling our scripts \
    //basically a delegate that takes in a object sender and EverntArgs
    //See CombatUI For More Details
    //EventHandlers
    public event EventHandler OnCombatStateTurnOn;
    public event EventHandler OnCombatStateTurnOff;
    public override void Enter()
    {
        OnCombatStateTurnOn?.Invoke(this, EventArgs.Empty);
        CombatManager.instance.DecideWhoTurn();
        base.Enter();
    }

    public override void Update()
    {
        GameManager.instance.PauseGame();
    }

    public override void Exit()
    {
        //turn off combat panels
        GameManager.instance.selectedEntity = null;
        OnCombatStateTurnOff?.Invoke(this, EventArgs.Empty);
        base.Exit();
    }
}
