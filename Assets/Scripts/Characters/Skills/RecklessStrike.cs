using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecklessStrike :Skills
{
    private int hitpenalty = 25;
     public RecklessStrike()
    {
        skillName = "Reckless Strike";
        skillDesc = "Strike with reckless abandon. High damage if it hits";
    }

    public override void CastSkill(LivingEntities target, LivingEntities self)
    {
            self.AttackWithHitPenalty(target, (int)(self.AttackStat * 1.5),hitpenalty);
    }
}
