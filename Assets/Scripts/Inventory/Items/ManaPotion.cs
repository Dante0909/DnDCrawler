using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPotion : ConsumableItem
{
    private Image image;
    
    public ManaPotion()
    {
        name = "Mana potion";
        description = "Potion that restores the mage or cleric's mana gauge.";
    }

    public override Sprite GetSprite()
    {
        return ItemAssets.Instance.manaPotionSprite;

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
