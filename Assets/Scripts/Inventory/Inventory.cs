using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Inventory
{
    private List<ConsumableItemA> consumableItems;
    public event EventHandler OnItemListChanged;
    IEnumerable<ConsumableItemA> IEnumCI;

    public Inventory()
    {
        consumableItems = new List<ConsumableItemA>();
        IEnumCI = ReflectiveEnumerator.GetEnumerableOfType<ConsumableItemA>();
        Ui_Inventory.instance.SetInventory(this);

    }
    public void AddItem(ItemA item)
    {
        if(item is ConsumableItemA)
        {
            foreach (ConsumableItemA c in IEnumCI)                       //for all the classes of ConsumableItems
            {
                if (c.GetType() == item.GetType())                      //is the item a manapotion, health potion, etc(dynamic)
                {
                    if (DetectItem(consumableItems, c))                 //checks if the list contains that objects at least once
                        consumableItems.Where(x => x.GetType() == c.GetType()).First().amount++;
                                                                        //adds one to the count if yes
                    
                    else consumableItems.Add((ConsumableItemA)item);     //creates new entry if not
                    break;
                }
            }
            OnItemListChanged?.Invoke(this, EventArgs.Empty);           //updates ui
            return;
        }
    }
    public bool DetectItem<T>(List<ConsumableItemA> genericList, T type)
    {
        foreach (ConsumableItemA c in genericList)
        {
            if (c.GetType() == type.GetType()) return true;
        }

        return false;
    }
    public List<ConsumableItemA> GetConsumableItems()
    {
        return consumableItems;
    }
    public List<ConsumableItemA> GetCombatItems()
    {
        return consumableItems.Where(x => x.isUsableInCombat == true).ToList();
    }
}