using UnityEngine;

[DisallowMultipleComponent]
public class AIStats : MonoBehaviour
{
    AICore core;
    [HideInInspector]
    public bool isSpawned = false;
    [HideInInspector]
    public AISpawner spawner;
    [Header("Speed")]
    [Tooltip("Walking Speed.")]
    public float walkSpeed = 1f;
    [Tooltip("This will override the walking speed and assign a random walk speed.")]
    public bool randomWalkSpeed = false;
    [Tooltip("Running Speed.")]
    public float runSpeed = 2f;
    [Tooltip("This will override the running speed and assign a random run speed.")]
    public bool randomRunSpeed = false;
    [Header("Health")]
    [Tooltip("Maximum health.")]
    public int maxHealth = 100;
    [Tooltip("Current health.")]
    public float Health = 100f;
    [Tooltip("Rate at which health regenerates.")]
    public float healthRegen = 3f;   
    [Header("Stamina")]
    [Tooltip("Current stamina.")]
    public float stamina = 100f;
    [Tooltip("Maximum stamina.")]
    public int maxStamina = 100;
    [Tooltip("Rate at which stamina regenerates.")]
    public float staminaRegen = 1f;    
    [Header("Patrol Timer")]
    public float patrolTimer = 200f;
    [HideInInspector]
    public float patrolWaitTime = 30f;
    [Header("Level")]
    [Tooltip("Current level, base stats will remain. levelToReach = levelProgMax * level * 2")]
    public int level = 1;
    [Tooltip("Maximum obtainable level.")]
    public int maxLevel = 25;
    [Tooltip("Current Progression Level.")]
    public int levelProg = 0;
    [Tooltip("Current Max Progression Level. When reached the AI levels up")]
    public int levelProgMax = 2;
    [Space]
    [Tooltip("How far the AI can detect enemies.")]
    [Range(2, 30)]
    public int Sight = 20;
    [Tooltip("Base damage multiplied by attack type.")]
    public int damage = 5;
    [Space]
    [Tooltip("Stats can regenerate.")]
    public bool canRegen = true;
    [Tooltip("Instantiates random loot.")]
    public bool randomLoot = true;
    [Tooltip("Instantiates blood.")]
    public bool instantiateBlood = true;

    void Start()
    {
        core = GetComponent<AICore>();
        patrolTimer = patrolWaitTime;
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
            if (stamina < maxStamina)
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

        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
    }
}
