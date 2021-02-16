using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief :LivingEntities
{
   

    protected override void Start()
    {
        Skill = new PickPocket();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Pick lock skill uses a lockpick to attempt a roll to pick a lock
}
