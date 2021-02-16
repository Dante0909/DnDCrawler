using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICombat : MonoBehaviour
{
    GameManager gameManager;


    [Header("UI ELEMENTS", order = 0)]
    [SerializeField] public GameObject combatPanel;
    [SerializeField] public GameObject characterSelectPanel;
    [SerializeField] public GameObject actionSelectPanel;
    [SerializeField] public GameObject inventoryPanel;
    void Start()
    {
        gameManager = GameManager.instance;
        //Find the event in the combat state subscribe the methods to it
        if (gameManager != null)
        {
            gameManager.combatState.OnCombatStateTurnOn += CombatUIOnStart;
            gameManager.combatState.OnCombatStateTurnOff += CombatUIOnEnd;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //These are essentially shell methods to call the turn on and of combatUI methods
    //only difference is that these fit the delgate parameters 
    private void CombatUIOnStart(object sender, System.EventArgs e)
    {
        TurnOnCombatUI();
    }
    private void CombatUIOnEnd(object sender, System.EventArgs e)
    {
        TurnOffCombatUI();
    }
    private void TurnOffCombatUI()
    {
       combatPanel.SetActive(false);
       characterSelectPanel.SetActive(false);
       actionSelectPanel.SetActive(false);
    }
    private void TurnOnCombatUI()
    {
        
       combatPanel.SetActive(true);
       characterSelectPanel.SetActive(true);
       actionSelectPanel.SetActive(false);
    }

}
