using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private LivingEntities selectedHero;
    [SerializeField] private GameObject attackSelection;
    [SerializeField] private GameObject itemUI;
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
        GameManager.instance.selectedEntity = selectedHero;
        attackSelection.SetActive(true);
        
    }

    public void AttackOption()
    {
        combatManager.isSelectingEnemy = true;
        combatManager.option = CombatManager.action.Attack;
    }
    
    public void SkillOption()
    {
        combatManager.isSelectingEnemy = true;
        combatManager.option = CombatManager.action.Skill;
    }
    public void ItemOption()
    {
        itemUI.SetActive(true);
    }
}
