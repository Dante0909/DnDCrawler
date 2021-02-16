using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ConsumableItemA : ItemA
{
    public abstract void OnConsumed();
    public int amount;
    public bool isUsableInCombat;
    
    public ConsumableItemA()
    {
        amount = 1;
    }
}
