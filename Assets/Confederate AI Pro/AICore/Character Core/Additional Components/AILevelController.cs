using UnityEngine;

[DisallowMultipleComponent]
public class AILevelController : MonoBehaviour
{
    AICore core;

    int multiplier;

    void Start()
    {
        core = GetComponent<AICore>();
    }

    public void UpdateLevel()
    {
        if (core.stats.level > core.stats.maxLevel)
        {
            core.stats.level = core.stats.maxLevel;
            int levelToReach = core.stats.levelProgMax * core.stats.level * 2;

            if (core.stats.levelProg >= levelToReach)
            {
                levelUp();
            }
        }        
    }

    void levelUp()
    {
        core.animator.isLevel();

        core.stats.level += 1;
        core.stats.levelProg = 0; 
        core.stats.levelProgMax += core.stats.level * 2; 

        if (core.stats.level <= core.stats.maxLevel)
        {
            UpdateStats();
        }
    }

    void UpdateStats()
    {
        core.stats.maxHealth += core.variables.LevelHealthIncrease * multiplier;
        core.stats.maxStamina += core.variables.LevelStaminaIncrease * multiplier;
        core.stats.damage += core.variables.LevelDamageIncrease * multiplier;
        core.stats.Health = core.stats.maxHealth;
        core.stats.stamina = core.stats.maxStamina;
    }
}
