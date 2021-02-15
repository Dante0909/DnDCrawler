using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    string name = "Default name";
    string description = "Default description";

    public abstract void OnDelete();
    public abstract void OnGrab();

}
