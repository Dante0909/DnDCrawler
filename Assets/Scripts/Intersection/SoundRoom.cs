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
        if(Random.value > 0.5f)
        {
            isNoisy = true;
            switch (Random.Range(0, 1))
            {
                case 1: return "You can hear monsters roaming.\n";
                default: return "Growls can be heard coming from this way.\n";
            }
        }
        else
        {
            isNoisy = false;
            switch (Random.Range(0, 1))
            {
                case 1: return "There is a calming quietness emanating from this path.\n";
                default: return "This avenue seems more peaceful.\n";
            }
        }
        
        
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
