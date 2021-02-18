using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerCharacters
{

    protected override void Start()
    {
        Skill = new RecklessStrike();
        base.Start();
    }

}
