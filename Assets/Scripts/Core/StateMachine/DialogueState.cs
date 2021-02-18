using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState :GameStates
{
    public event EventHandler OnDialogueStateEnter;
    public event EventHandler OnDialogueStateExit;

    

    public RoomInfo roomInfo;

    public override void Enter()
    {
        OnDialogueStateEnter?.Invoke(this, EventArgs.Empty);
        GenerateDialogue();
    }

    public override void Update()
    {
        GameManager.instance.PauseGame();
    }


    public override void Exit()
    {
        OnDialogueStateExit?.Invoke(this, EventArgs.Empty);
    }

    private void GenerateDialogue()
    {

    }


}
