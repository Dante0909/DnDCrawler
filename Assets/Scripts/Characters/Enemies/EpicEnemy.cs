using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpicEnemy : EnemyEntity
{
    // Start is called before the first frame update
    override protected void Start()
    {
        
        health = Random.Range(250,300);
        attackStat = Random.Range(35, 40);
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
