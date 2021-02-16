using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsumableItem : Item
{
    public abstract void OnConsumed();
    public int amount;
    
    public ConsumableItem()
    {
        amount = 1;
    }
}
