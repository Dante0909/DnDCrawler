using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private LivingEntities character;
    [SerializeField] private Text info;
    private int currentMana;

    public int CurrentMana { get => currentMana; set => currentMana = value; }

    void Start()
    {
        slider.maxValue = character.MaxMana;
        slider.value = character.Mana;
        SetTextStats();
    }

    public void SetHealth(int mana)
    {
        slider.value = mana;
        currentMana = character.Mana;
        SetTextStats();
    }

    public void SetTextStats()
    {
        currentMana = character.Mana;
        info.text = currentMana + "/" + character.MaxMana;
    }
}
