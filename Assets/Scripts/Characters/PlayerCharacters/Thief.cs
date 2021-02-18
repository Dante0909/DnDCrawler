using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief :PlayerCharacters
{
   

    protected override void Start()
    {
        Skill = new PickPocket();
        base.Start();
    }

}
