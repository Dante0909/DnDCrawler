using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private LivingEntities character;
    [SerializeField] private Text info;
    private int currentHealth;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    void Start()
    {
        slider.maxValue = character.MaxHealth;
        slider.value = character.Health;
        SetTextStats();
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        currentHealth = character.Health;
        SetTextStats();
    }

    public void SetTextStats()
    {
        currentHealth = character.Health;
        info.text = currentHealth + "/" + character.MaxHealth;
    }
}
