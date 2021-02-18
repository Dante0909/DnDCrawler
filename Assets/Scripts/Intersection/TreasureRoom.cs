using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : RoomEffectsA
{

    public override bool IsActive { get => IsActive; set => IsActive = value; }

    public override string GetDescription()
    {
        return "Treasure";
    }
    public override int GetID()
    {
        return 0;
    }
}
