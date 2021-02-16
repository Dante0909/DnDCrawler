using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : LivingEntities
{
    [SerializeField] private GameObject selectorSprite;

    public GameObject SelectorSprite { get => selectorSprite; set => selectorSprite = value; }

    protected void Skill(LivingEntities target)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack(LivingEntities target)
    {
        int hitchance = CalcHitChance();
        if (DiceRoller.RollDice() < hitchance)
        {
            int critChance = Motivation / 5;
            int damageToDeal = DiceRoller.RollDice() < critChance ? (int)(AttackStat * 1.5) : AttackStat;
            target.TakeDamage(damageToDeal);
            Debug.Log(target);
            Debug.Log(hitchance);
        }
    }

    public void OnMouseOver()
    {
        if (CombatManager.instance.isPlayerTurn && CombatManager.instance.isSelectingEnemy)
        {
            SelectorSprite.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        if (CombatManager.instance.isPlayerTurn && CombatManager.instance.isSelectingEnemy)
        {
            SelectorSprite.SetActive(false);
        }
    }

    public void OnMouseUp()
    {
        if (CombatManager.instance.isPlayerTurn && CombatManager.instance.isSelectingEnemy)
        {
            CombatManager.instance.PerformAction(this);
        }
    }

}
