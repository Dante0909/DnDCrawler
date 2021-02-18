using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedRoom : RoomEffectsA
{
    public override bool IsActive { get => IsActive; set => IsActive = value; }

    public override string GetDescription()
    {
        return "Locked";
    }
    public override int GetID()
    {
        return 1;
    }
}
