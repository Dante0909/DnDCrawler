using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball :Skills
{

    private const int fireBallCost = 25;
    public Fireball()
    {
        skillName = "Fireball";
        skillDesc = "Get 5head from a girl in chat";
    }
  
public override void CastSkill(LivingEntities target, LivingEntities self)
    {
        if (self.Manacheck(fireBallCost))
        {
            self.DeductMana(fireBallCost);
            self.Attack(target, (int)(self.AttackStat * 1.5));
        }
        else
        {
            MonoBehaviour.print("NOT ENOUGH MANA");
        }
    }
}
