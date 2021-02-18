using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyEntity : LivingEntities
{
    [SerializeField] private GameObject selectorSprite;

    private Animator animator;
    protected Camera main;
    public GameObject SelectorSprite { get => selectorSprite; set => selectorSprite = value; }

    protected void Skill(LivingEntities target)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    protected override void Start()
    {

        animator = GetComponent<Animator>();
        main = Camera.main;
       
        base.Start();
        //ConstraintSource camera = new ConstraintSource();
        //camera.sourceTransform = Camera.main.transform;
        //camera.weight = 1;
        //if (GetComponent<LookAtConstraint>())
        //    GetComponent<LookAtConstraint>().SetSource(0, camera);
    }

    protected void LookAt()
    {
        Vector3 vector =main.transform.position - this.transform.position;
        vector.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(vector), .1f);
       
    }

    // Update is called once per frame
    virtual protected void Update()
    {
            LookAt();
        
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
    public void Attack(LivingEntities target)
    {
        int hitchance = CalcHitChance();
        if (DiceRoller.RollDice() < hitchance)
        {
            int critChance = Motivation / 5;
            int damageToDeal = DiceRoller.RollDice() < critChance ? (int)(AttackStat * 1.5) : AttackStat;
            target.TakeDamage(damageToDeal);

            animator.SetTrigger("Attack");

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
