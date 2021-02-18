using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedRoom : RoomEffectsA
{
    public override bool IsActive { get => IsActive; set => IsActive = value; }

    public override string GetDescription()
    {
        switch (Random.Range(0, 2))
        {
            case 1: return "It won't open without a key.\n";
            case 2: return "The door has a keyhole.\n";
            default: return "The door is locked.\n";
        }
    }
    public override int GetID()
    {
        return 1;
    }
}
