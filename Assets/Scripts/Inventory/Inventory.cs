using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Reflection;

public class Inventory
{
    private List<ConsumableItem> consumableItems;
    public event EventHandler OnItemListChanged;
    List<ConsumableItem> IEnumCI;

    public Inventory()
    {
        consumableItems = new List<ConsumableItem>();
        IEnumCI = ReflectiveEnumerator.GetEnumerableOfType<ConsumableItem>();

        foreach (ConsumableItem c in IEnumCI)
        {
            Debug.Log(c);
        }
    }
    

    
    public void AddItem(Item item)
    {
        if(item is ConsumableItem)
        {
            foreach (ConsumableItem c in IEnumCI)                       //for all the classes of ConsumableItems
            {
                if (c.GetType() == item.GetType())                      //is the item a manapotion, health potion, etc(dynamic)
                {
                    if (DetectItem(consumableItems, c))                 //checks if the list contains that objects at least once
                        consumableItems.Where(x => x.GetType() == c.GetType()).First().amount++;
                                                                        //adds one to the count if yes
                    
                    else consumableItems.Add((ConsumableItem)item);     //creates new entry if not
                    break;
                }
            }
            OnItemListChanged?.Invoke(this, EventArgs.Empty);           //updates ui
            return;
        }
    }
    public bool DetectItem<T>(List<ConsumableItem> Within, T type)
    {
        foreach (ConsumableItem c in Within)
        {
            if (c.GetType() == type.GetType()) return true;
        }

        return false;
    }
    public List<ConsumableItem> GetConsumableItems()
    {
        return consumableItems;
    }
}
public static class ReflectiveEnumerator            //returns all the subclasses of a class
{
    static ReflectiveEnumerator() { }

    public static List<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
    {
        List<T> objects = new List<T>();
        foreach (Type type in
            Assembly.GetAssembly(typeof(T)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
        {
            objects.Add((T)Activator.CreateInstance(type, constructorArgs));
        }
        return objects;
    }
}
