using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : RoomEffectsA
{

    public override bool IsActive { get => IsActive; set => IsActive = value; }

    public override string GetDescription()
    {
        switch (Random.Range(0, 1))
        {
            case 1: return "The room contains a valuable treasure.\n";
            default: return "Riches await you.\n";
        }
    }
    public override int GetID()
    {
        return 0;
    }
}
