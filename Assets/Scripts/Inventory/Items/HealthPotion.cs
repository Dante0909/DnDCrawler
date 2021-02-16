using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HealthPotion : ConsumableItemA
{
    public HealthPotion()
    {
        name = "Health potion";
        description = "Potion that heals a traveller of your choice.";
        isUsableInCombat = true;
    }

    public override Sprite GetSprite()
    {
        return ItemAssets.Instance.healthPotionSprite;
    }

    public override void OnConsumed()
    {
        Debug.Log("health potion");
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
