using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    private static int theStats;
    public static int RollDice()
    {
        theStats = Random.Range(1, 100);
        Debug.Log("The Dice: " + theStats);
        return theStats;
    }
    public static bool PickpocketCheck(LivingEntities entity)
    {
        return DiceRoller.RollDice() < (entity.Motivation - 20);
    }
    public static int RollDFour()
    {
        theStats = Random.Range(0, 4);
        Debug.Log("The D4: " + theStats);
        return theStats;
    }
}
