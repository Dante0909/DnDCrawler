using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntities : MonoBehaviour
{


    //Bar Related Stats
    protected int health;
    protected int maxHealth;
    protected int motivation;
    protected const int maxMotivation = 100;
    //Not every class may have mana but to avoid alot of inheritance I will put mana in here
    //If thats not liked I can create a subclass MagicEntites where this can be placed
    //for now just for warrior and thief set mana to 0
     protected int mana;
     protected int maxMana;

    [SerializeField] private StatsBar hpBar;

     protected int attackStat;
     protected Skills skill;

     protected bool isDead = false;
     protected bool didTurn = false;

    //Theoretical
    //[SerializedField] private Abilites classArchetype;
    //A theory for the combat skills make a greater class called abilites each might not be 
    //neccesary

    #region Properties
    //Properties
    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int Motivation { get => motivation; set => motivation = value; }
    public int Mana { get => mana; set => mana = value; }
    public int MaxMana { get => maxMana; set => maxMana = value; }

    //Is Dead can be used to determine if actions are possible
    public bool IsDead { get => isDead; }
    public int AttackStat { get => attackStat; set => attackStat = value; }
    public Skills Skill { get => skill; set => skill = value; }
    public bool DidTurn { get => didTurn; set => didTurn = value; }

    #endregion Properties

    protected virtual void Start()
    {    

        health = MaxHealth;
        mana = MaxMana;
    }

    /// <summary>
    /// Take damage allows for damage to be taken if health is lower than 0 Die will be called
    /// </summary>
    /// <param name="damage"></param>
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        hpBar.SetHealth(health);
        if (health <= 0)
        {
            Die();
        }
    }
    /// <summary>
    /// Heal will heal for an amount will not overheal
    /// </summary>
    /// <param name="amount"></param>
    public void HealHealth(int amount)
    {
        Health = Health + amount >= MaxHealth ? MaxHealth : Health + amount;
        hpBar.SetHealth(health);
    }
    /// <summary>
    /// HealMana will heal mana by and amount will not overheal
    /// </summary>
    /// <param name="amount"></param>
    public void HealMana(int amount)
    {
        Mana = Mana + amount >= MaxMana ? MaxMana : Mana + amount;
    }

    private void Die()
    {
        isDead = true;
        if (GetComponent<Animator>() != null)
        {
            UnityEngine.Random.Range(0, 1);
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<Animator>().SetInteger("DeathAnim", 1);
        }
        CombatManager.instance.CheckIfAllHeroesDead();

    }

    /// <summary>
    /// Attack takes a target livingEntity and will check if it crits then perform an attack
    /// based on your attackStat
    /// </summary>
    /// <param name="target"></param>
    public virtual void Attack(LivingEntities target)
    {
        int hitchance = CalcHitChance();
        if (DiceRoller.RollDice() < hitchance)
        {
            int critChance = CalcCritChance();
            int damageToDeal = DiceRoller.RollDice() < critChance ? (int)(AttackStat * 1.5) : AttackStat;
            target.TakeDamage(damageToDeal);
        }

    }
    public virtual void Attack(LivingEntities target, int attackDamage)
    {
        int hitchance = CalcHitChance();
        if (DiceRoller.RollDice() < hitchance)
        {
            int critChance = Motivation / 5;
            int damageToDeal = DiceRoller.RollDice() < critChance ? (int)(attackDamage * 1.5) : attackDamage;
            target.TakeDamage(damageToDeal);
        }

    }
    public virtual void AttackWithHitPenalty(LivingEntities target, int attackDamage,int hitPenalty)
    {
        int hitchance = CalcHitChance(hitPenalty);
        if (DiceRoller.RollDice() < hitchance)
        {
            int critChance = Motivation / 5;
            int damageToDeal = DiceRoller.RollDice() < critChance ? (int)(attackDamage * 1.5) : attackDamage;
            target.TakeDamage(damageToDeal);
        }

    }

    public int CalcCritChance()
    {
        return Motivation / 5;
    }


    public bool Manacheck(int manacost)
    {
        return Mana >= manacost;
    }
    public void DeductMana(int manacost)
    {
        Mana = Mana - manacost < 0 ? 0 : Mana - manacost;
    }
    public int CalcHitChance()
    {
        return (int)(100 - (maxMotivation - Motivation*1.25));
    }
    public int CalcHitChance(int hitPenalty)
    {
        return (int)(100 - (maxMotivation - Motivation*1.25-hitPenalty));
    }
    public virtual void UseSkill(LivingEntities target)
    {
        skill.CastSkill(target, this);
    }
    public void LoseMotivation(int amount)
    {
        motivation -= amount;
    }
}
