using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest :PlayerCharacters
{

    protected override void Start()
    {
        Skill = new Heal();
        base.Start();
    }



}
