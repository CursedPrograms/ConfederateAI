using UnityEngine;
using ThirdPersonControl;

[DisallowMultipleComponent]
public class AIAttack : MonoBehaviour
{
    AICore core;

    GameObject BloodSpatter;

    bool isAttacking;

    int levelMulti;
    int damageMulti;
    int staminaDrain;
    [Range(0.3f, 4f)]
    public float attackTimer = 4f;
    [Space]
    float attackTime;
    [Header("AI Target - Auto Assigned")]
    public Transform Target = null;
    Transform myTransform;

    void Awake()
    {
        core = GetComponent<AICore>();
    }

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("GameController").transform;
        BloodSpatter = core.gameController.GetComponent<AIObjects>().bloodSpatter;

        myTransform = transform;
        attackTime = attackTimer;
    }

    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            return;
        }
        else
        {
            if (Target != null)
            {
                Attack();
            }
            attackTimer = attackTime;
        }
    }

    void Attack()
    {
        float direction;
        bool canAttack;

        GetDistDir(out direction, out canAttack);

        int tempDamageMulti = 0;
        int tempLevelMulti = 0;
        int tempStaminaDrain = 0;

        if (canAttack && direction > 0)
        {
            if (core.stats.stamina >= core.variables.attack01StaminaDrain)
            {
                core.animator.isAttack01();
                AssignValues(tempDamageMulti = 2, tempLevelMulti = 1, tempStaminaDrain = core.variables.attack01StaminaDrain);
            }
            else if (core.stats.stamina >= core.variables.attack02StaminaDrain)
            {
                core.animator.isAttack02();
                AssignValues(tempDamageMulti = 4, tempLevelMulti = 2, tempStaminaDrain = core.variables.attack02StaminaDrain);
            }
            else if (core.stats.stamina >= core.variables.attack03StaminaDrain)
            {
                core.animator.isAttack03();
                AssignValues(tempDamageMulti = 6, tempLevelMulti = 3, tempStaminaDrain = core.variables.attack03StaminaDrain);
            }
            else
            {
                core.animator.isIdle();
            }
            AttackEnemy();
        }
    }

    void AttackEnemy()
    {
        if (Target.tag == "Player")
        {
            if (Target.GetComponent<PlayerStats>())
            {
                Target.GetComponent<PlayerStats>().Health -= core.stats.damage * damageMulti;
                core.Audio.TargetHit();
            }
        }
        else
        {
            if (Target.GetComponent<AIStats>())
            {
                AIStats EnemyStats = Target.GetComponent<AIStats>();
                EnemyStats.Health -= core.stats.damage * damageMulti;
                EnemyStats.UpdateHealth();
            }
        }

        core.stats.levelProg += levelMulti;
        core.level.UpdateLevel();

        core.stats.stamina -= staminaDrain;
        core.stats.UpdateStamina();

        if (BloodSpatter)
        {
            Instantiate(BloodSpatter, Target.transform.position, Target.transform.rotation);
        }
    }

    void AssignValues(int tempDamageMulti, int tempLevelMulti, int tempStaminaDrain)
    {
        damageMulti = tempDamageMulti;
        levelMulti = tempLevelMulti;
        staminaDrain = tempStaminaDrain;
    }

    void GetDistDir(out float direction, out bool canAttack)
    {
        if (myTransform == null)
        {
            myTransform = transform;
        }

        float distance = Vector3.Distance(Target.transform.position, myTransform.position);
        Vector3 dir = (Target.transform.position - myTransform.position).normalized;
        direction = Vector3.Dot(dir, transform.forward);
        canAttack = distance < 1.5;
    }
}
