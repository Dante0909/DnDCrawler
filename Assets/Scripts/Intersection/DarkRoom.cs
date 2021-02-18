using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoom : RoomEffectsA
{
    public override bool IsActive { get => IsActive; set => IsActive = value; }

    public override string GetDescription()
    {
        switch (Random.Range(0, 3))
        {
            case 1: return "You have trouble seeing far in the distance.\n";
            case 2: return "The room looks pitch black.\n";
            case 3: return "The darkness sends you chills.\n";
            default: return "The room looks dark and gloomy.\n";
        }
    }
    public override int GetID()
    {
        return 2;
    }
}
