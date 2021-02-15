using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage :LivingEntities
{
    //lower base hp and attack 
    //Maybe a cast fireball attack

     private const int readRuneCost = 20;
    private const int fireBallCost = 25;

    public void ReadRune(/*Rune rune*/)
    {
        if (Mana > readRuneCost)
        {
            //will take a rune Probably Scriptable object that will contain a good reading
            //and bad reading, then roll to see if mage reads good reading or bad then display
        }
        else
        {
            print("NOT ENOUGH MANA");
        }


    }


    protected override void Start()
    {
        base.Start();
    }


}
