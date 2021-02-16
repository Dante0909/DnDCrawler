using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private LivingEntities selectedHero;
    [SerializeField] private GameObject attackSelection;
    private CombatManager combatManager;
    // Start is called before the first frame update
    void Start()
    {
        combatManager = CombatManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectCharacter()
    {
        combatManager.selectedEntity = selectedHero;
        attackSelection.SetActive(true);
        
    }
}
