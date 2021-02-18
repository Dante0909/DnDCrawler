using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoom : RoomEffectsA
{
    public override bool IsActive { get => IsActive; set => IsActive = value; }

    public override string GetDescription()
    {
        return "Dark room";
    }
    public override int GetID()
    {
        return 2;
    }
}
