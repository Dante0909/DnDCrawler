using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : ConsumableItem
{
    public HealthPotion()
    {
        name = "Health potion";
        description = "Potion that heals a traveller of your choice.";
    }

    public override Sprite GetSprite()
    {
        return ItemAssets.Instance.healthPotionSprite;
    }

    public override void OnConsumed()
    {
        //heal player
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
