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
    [SerializeField]private GameObject buttonParentHero;
    public LivingEntities selectedEntity;
    [SerializeField] private List<EnemyEntity> currentEnemies = new List<EnemyEntity>();
    bool onlyonce = true;
    [SerializeField] private List<LivingEntities> allLivingHeroes = new List<LivingEntities>();
    // Start is called before the first frame update
    void Start()
    {
        GatherEnenmyForFight();
        GatherHeroForFight();
    }
    
    // Update is called once per frame
    void Update()
    {
        
         if(Input.GetButton("Jump"))
         {
            if (onlyonce)
            {
                onlyonce = false;
                NowPlayerTurn();
            }
         }
        
    }

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


}
