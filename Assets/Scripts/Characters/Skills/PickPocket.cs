using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPocket : Skills
{
    public PickPocket()
    {
        skillName = "PicketPocket";
        skillDesc = "Try and plunder an item from the pockets of your enemies";
    }

    public override void CastSkill(LivingEntities target, LivingEntities self)
    {
        if (DiceRoller.PickpocketCheck(self))
        {
            int itemToSteal = Random.Range(1, 4);
            switch (itemToSteal)
            {
                case 1:
                   MonoBehaviour.print("Potion Stolen");
                    break;
                case 2:
                    MonoBehaviour.print("Mana Potion Stolen");
                    break;
                case 3:
                    MonoBehaviour.print("LockPick Stolen");
                    break;

            }

        }
    }
}
