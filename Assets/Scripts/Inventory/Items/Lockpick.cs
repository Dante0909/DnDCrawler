using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpick : ConsumableItem
{
    public Lockpick()
    {
        name = "Lockpick";
        description = "Allows the thief to unlock alternate paths.";
    }

    public override Sprite GetSprite()
    {
        return ItemAssets.Instance.keySprite;
    }

    public override void OnConsumed()
    {
        
    }

    public override void OnDelete()
    {
        throw new System.NotImplementedException();
    }

    public override void OnGrab()
    {
        throw new System.NotImplementedException();
    }
}
