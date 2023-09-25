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
        }

        int levelToReach = core.stats.levelProgMax * core.stats.level * 2;

        if (core.stats.levelProg >= levelToReach)
        {
            levelUp();
        }
    }

    void levelUp()
    {
     //   core.animator.isLevel();

        core.stats.level += 1;
        core.stats.levelProg = 0;
        core.stats.levelProgMax += core.stats.level * 2;

        core.stats.maxLevelProg = core.stats.levelProgMax * core.stats.level * 2;

        if (core.stats.level <= core.stats.maxLevel)
        {
            if (core.stats.level >= 1 && core.stats.level < 12)
            {
                SetToNovice();
            }
            else if (core.stats.level >= 12 && core.stats.level < 20)
            {
                SetToAdept();
            }
            else if (core.stats.level >= 20 && core.stats.level <= core.stats.maxLevel)
            {
                SetToMaster();
            }

            UpdateStats();
        }
    }

    void SetToMaster()
    {
        core.stats.Novice = false;
        core.stats.Adept = false;
        core.stats.Master = true;
    }

    void SetToAdept()
    {
        core.stats.Novice = false;
        core.stats.Adept = true;
        core.stats.Master = false;
    }

    void SetToNovice()
    {
        core.stats.Novice = true;
        core.stats.Adept = false;
        core.stats.Master = false;
    }

    void UpdateStats()
    {
        if (core.stats.Novice == true)
        {
            multiplier = 1;
        }

        else if (core.stats.Adept == true)
        {
            multiplier = 2;
        }

        else if (core.stats.Master == true)
        {
            multiplier = 3;
        }

        core.stats.maxHealth += core.variables.LevelHealthIncrease * multiplier;
        core.stats.maxstamina += core.variables.LevelStaminaIncrease * multiplier;
        core.stats.damage += core.variables.LevelDamageIncrease * multiplier;
        core.stats.Health = core.stats.maxHealth;
        core.stats.stamina = core.stats.maxstamina;
    }
}
