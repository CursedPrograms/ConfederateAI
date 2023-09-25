using UnityEngine;

[DisallowMultipleComponent]
public class AIMovement : MonoBehaviour
{
    AICore core;

    bool walking;
    bool running;
    bool idle;

    void Awake()
    {
        core = GetComponent<AICore>();
    }

    void Start()
    {
        if (core.stats.randomWalkSpeed || core.stats.randomRunSpeed)
        {
            GenerateSpeed();
        }
    }

    void GenerateSpeed()
    {
        if (core.stats.randomWalkSpeed)
        {
            core.stats.walkSpeed = Random.Range(0.9f, 1.1f);
        }

        if (core.stats.randomRunSpeed)
        {
            core.stats.runSpeed = Random.Range(1.7f, 2.2f);
        }
    }

    public void isRunning()
    {
            core.navAgent.enabled = true;
            core.navObstacle.enabled = false;
            core.navAgent.speed = core.stats.runSpeed;
            core.animator.isRunning();
    }

    public void isWalking()
    {
            core.navAgent.enabled = true;
            core.navObstacle.enabled = false;
            core.navAgent.speed = core.stats.walkSpeed;
            core.animator.isWalking();
    }

    public void isIdle()
    {
            core.navAgent.enabled = false;
            core.navObstacle.enabled = true;
            core.navAgent.speed = 0;
            core.animator.isIdle();
    }
}
