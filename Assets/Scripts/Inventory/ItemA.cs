using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemA
{
    public string name = "Default name";
    public string description = "Default description";
    
    public abstract void OnDelete();
    public abstract void OnGrab();
    public abstract Sprite GetSprite();
}
