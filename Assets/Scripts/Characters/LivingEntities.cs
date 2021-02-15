using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntities : MonoBehaviour
{


    //Bar Related Stats
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int motivation;

    //Not every class may have mana but to avoid alot of inheritance I will put mana in here
    //If thats not liked I can create a subclass MagicEntites where this can be placed
    //for now just for warrior and thief set mana to 0
    [SerializeField] private int mana;
    [SerializeField] private int maxMana;

    //Probably need some sort of attack stat for combat
    // or can go a component based approach and create a fighter script

    [SerializeField] private bool isDead = false;

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
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
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
        //Add Death SFX and other functionalites 

    }
}
