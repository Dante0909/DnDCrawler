using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage :PlayerCharacters
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
        health = 200;
        attackStat = 20;
        MaxHealth = 100;

        Skill = new Fireball();
        base.Start();
    }


}
