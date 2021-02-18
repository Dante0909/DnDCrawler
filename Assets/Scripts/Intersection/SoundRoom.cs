using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRoom : RoomEffectsA
{
    private bool isNoisy;
    private string description;
    public override bool IsActive { get => IsActive; set => IsActive = value; }

    public override string GetDescription()
    {
        isNoisy = Random.value > 0.5f ? true : false; 
        return "Growls can be heard";
    }
    public bool GetNoisy()
    {
        return isNoisy;
    }
    public override int GetID()
    {
        return 4;
    }
    
}
