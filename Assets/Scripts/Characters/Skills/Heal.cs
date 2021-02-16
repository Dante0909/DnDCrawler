using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skills
{
    public Heal()
    {
        skillName = "Heal";
        skillDesc = "Heal the pain of your past";
    }


    private const int healCost = 20;
    private int healAmount;

    public override void CastSkill(LivingEntities target, LivingEntities self)
    {
        if (DiceRoller.RollDice() < self.CalcCritChance())
        {
           MonoBehaviour.print("Greater Heal");
            target.HealHealth((int)(healAmount * 1.5));
        }
        else
        {
           MonoBehaviour.print("Lesser Heal");
            target.HealHealth(healAmount);
        }
    }
}