using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    #region Singleton
    public static CombatManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion SingleTon
    public bool isPlayerTurn;
    public bool isSelectingEnemy = false;
    public enum action { Attack, Skill}
    public action option;
    [SerializeField]private GameObject buttonParentHero;
  
    [SerializeField] private List<EnemyEntity> currentEnemies = new List<EnemyEntity>();
    bool onlyonce = true;
    [SerializeField] private List<LivingEntities> allLivingHeroes = new List<LivingEntities>();
    private GameManager gameManager;

    //Cached Buttons
    private Button WarriorBtn;
    private Button MageBtn;
    private Button ThiefBtn;
    private Button PriestBtn;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameManager.instance;
        ThiefBtn = buttonParentHero.transform.Find("ThiefSelect").gameObject.GetComponent<Button>();
        WarriorBtn = buttonParentHero.transform.Find("WarriorSelect").gameObject.GetComponent<Button>();
        MageBtn=buttonParentHero.transform.Find("MageSelect").gameObject.GetComponent<Button>();
        PriestBtn = buttonParentHero.transform.Find("PriestSelect").gameObject.GetComponent<Button>();
    }
    // Update is called once per frame

    public void DecideWhoTurn()
    {
        GatherEnenmyForFight();
        GatherHeroForFight();
        int avgMotivation = 0;
        int totalhero = 0;
        for(int i = 0; i < allLivingHeroes.Count; i++)
        {
                avgMotivation += allLivingHeroes[i].Motivation;
                totalhero++;
           
        }
        avgMotivation = avgMotivation / totalhero;
        int chanceNum = DiceRoller.RollDice();
        int heroChance = 100 - avgMotivation;
        if (chanceNum > heroChance)
        {
            NowPlayerTurn();
        }
        else
        {
            StartEnemyTurn();
        }
    }
    public void GatherEnenmyForFight()
    {
        currentEnemies.AddRange(FindObjectsOfType(typeof(EnemyEntity)) as EnemyEntity[]);
    }
    public void GatherHeroForFight()
    {
        GameObject[] icons = GameObject.FindGameObjectsWithTag("Hero");
        for(int i = 0; i < icons.Length; i++)
        {
            if(!icons[i].GetComponent<LivingEntities>().IsDead)
            allLivingHeroes.Add(icons[i].GetComponent<LivingEntities>());
        }
    }
    public void StartEnemyTurn()
    {
        isPlayerTurn = false;
        TurnOffButton();
        for(int i = 0; i < currentEnemies.Count; i++)
        {
            int theTarget = DiceRoller.RollDFour();
            currentEnemies[i].Attack(allLivingHeroes[theTarget]);
        }
        NowPlayerTurn();
    }
    public void NowPlayerTurn()
    {
        isPlayerTurn = true;
        TurnOnButton();
    }
    public void TurnOnButton()
    {
        Button[] buton = buttonParentHero.GetComponentsInChildren<Button>();
        for(int i = 0; i < buton.Length; i++)
        {
            buton[i].interactable = true;
        }
    }
    public void TurnOffButton()
    {
        Button[] buton = buttonParentHero.GetComponentsInChildren<Button>();
        for (int i = 0; i < buton.Length; i++)
        {
            buton[i].interactable = false;
        }
    }
    public void TurnOffActionScreen()
    {
        GameObject skillGUI = GameObject.Find("ActionSelection");
        skillGUI.SetActive(false);
    }

    public void PerformAction(EnemyEntity Target)
    {
            GameObject skillGUI = GameObject.Find("ActionSelection");
            skillGUI.SetActive(false);
        switch (option)
        {
            case action.Attack:
               gameManager.selectedEntity.Attack(Target);
                gameManager.selectedEntity.DidTurn = true;
                isSelectingEnemy = false;
                Target.SelectorSprite.SetActive(false);
                CheckIfAllPlayersHaveGone();
                break;
            case action.Skill:
                gameManager.selectedEntity.UseSkill(Target);
                gameManager.selectedEntity.DidTurn = true;
                isSelectingEnemy = false;
                Target.SelectorSprite.SetActive(false);
                CheckIfAllPlayersHaveGone();
                break;
            default:
                break;
        }
    }

    public void CheckIfAllPlayersHaveGone()
    {
        TurnOffPlayerButton();
        foreach (LivingEntities hero in allLivingHeroes)
        {
            if(!hero.DidTurn)
            {
                return;
            }
        }
        Debug.Log("All Have Gone");
        StartEnemyTurn();
        
    }

    public void TurnOffPlayerButton()
    {

        if (gameManager.selectedEntity.GetType() == typeof(Warrior))
        {
            WarriorBtn.interactable = false;
        }
        else if (gameManager.selectedEntity.GetType() == typeof(Thief))
        {
            ThiefBtn.interactable = false;
        }
        else if (gameManager.selectedEntity.GetType() == typeof(Mage))
        {
           MageBtn.interactable = false;
        }
        else if (gameManager.selectedEntity.GetType() == typeof(Mage))
        {
          PriestBtn.interactable = false;
        }
    }

}

