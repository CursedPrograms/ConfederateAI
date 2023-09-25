using UnityEngine;

[DisallowMultipleComponent]
public class AIStats : MonoBehaviour
{
    AICore core;

    public bool isSpawned = false;
    public AISpawner spawner;

    public float walkSpeed = 1f;
    public bool randomWalkSpeed = true;
    public float runSpeed = 2f;
    public bool randomRunSpeed = true;

    public int maxHealth = 100;
    public float Health = 100f;
    public float healthRegen = 3f;

    public int damage = 5;

    public float stamina = 100f;
    public int maxstamina = 100;
    public float staminaRegen = 1f;

    public int Sight = 20;

    public float patrolTimer = 200f;
    public float patrolWaitTime = 30f;

    public int level = 1;
    public int maxLevel = 25;
    public int levelProg = 0;
    public int levelProgMax = 2;
    public int maxLevelProg = 100;

    public bool Novice = true;
    public bool Adept = false;
    public bool Master = false;

    public bool canRegen = true;

    public bool randomLoot = true;
    public bool instantiateBlood = true;

    void Start()
    {
        core = GetComponent<AICore>();
    }

    void Update()
    {
        Regen();
        UpdateTimer();
    }

    void Regen()
    {
        if (canRegen)
        {
            if (stamina < maxstamina)
            {
                if (stamina > 10)
                {
                    stamina += Time.deltaTime * staminaRegen;
                }
                UpdateStamina();
            }

            if (Health < maxHealth)
            {
                if (Health > 10)
                {
                    Health += Time.deltaTime * healthRegen;
                }
                UpdateHealth();
            }
        }
    }

    void UpdateTimer()
    {
        patrolTimer -= Time.deltaTime;

        if (patrolTimer < 0)
        {
            patrolTimer = 0;
        }
    }

    public void UpdateHealth()
    {
        if (Health < 0)
        {
            Health = 0;
        }

        if (Health == 0)
        {
            core.death.Death();
        }

        if (Health > maxHealth)
        {
            Health = maxHealth;
        }
    }

    public void UpdateStamina()
    {
        if (stamina < 0)
        {
            stamina = 0;
        }

        if (stamina > maxstamina)
        {
            stamina = maxstamina;
        }
    }
}
