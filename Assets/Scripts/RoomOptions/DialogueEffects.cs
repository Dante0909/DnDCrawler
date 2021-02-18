using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lower Motivation/Higher Motivation

[System.Serializable]
public class DialogueEffects :MonoBehaviour
{
    //This will be displayed on the button to choose this option
    public string entryDialogue;
    public bool keyRequired;
    
    [SerializeField] public PlayerCharacters[] playersAffected;
    [SerializeField] public int[] motivationChanges;
    [SerializeField] public int[] healthChanges;
    
    public virtual void RoomEffect()
    {

    }
}
