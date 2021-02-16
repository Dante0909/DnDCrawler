using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage :LivingEntities
{
    //lower base hp and attack 
    //Maybe a cast fireball attack

    private const int readRuneCost = 20;
    

    public void ReadRune(/*Rune rune*/)
    {
        if (Manacheck(readRuneCost))
        {
            DeductMana(readRuneCost);

        }
        else
        {
            print("NOT ENOUGH MANA");
        }


    }

  

    

    protected override void Start()
    {
        Skill = new Fireball();
        base.Start();
    }


}
