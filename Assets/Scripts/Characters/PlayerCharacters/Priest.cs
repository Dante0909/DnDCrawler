using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest :LivingEntities
{
    //standin value
    

    protected override void Start()
    {
        Skill = new Heal();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
