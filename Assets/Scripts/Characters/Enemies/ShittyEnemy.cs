using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyEnemy : EnemyEntity
{
    // Start is called before the first frame update
     protected override void Start()
    {
        health = Random.Range(100, 150);
        attackStat = Random.Range(25, 30);
        base.Start();
    }

    // Update is called once per frame
     protected override void Update()
    {
        base.Update();
    }
}
