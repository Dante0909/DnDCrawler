using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoomEffectsA
{
    public int aggro;
    public abstract int GetID();
    public abstract bool IsActive { get; set; }

    public abstract string GetDescription();
    
}
