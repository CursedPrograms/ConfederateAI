using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class AIMovement : MonoBehaviour
{
    AICore core;

    bool walking;
    bool running;
    bool idle;

    Transform _destination;

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
            core.stats.walkSpeed = UnityEngine.Random.Range(0.9f, 1.1f);
        }

        if (core.stats.randomRunSpeed)
        {
            core.stats.runSpeed = UnityEngine.Random.Range(1.7f, 2.2f);
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

    void calculatePath()
    {
        StartCoroutine(CalculatePath(_destination.transform.position, (path) => {
            // Do something with the path
        }));
    }

    IEnumerator CalculatePath(Vector3 destination, Action<NavMeshPath> onComplete)
    {
        NavMeshPath path = new NavMeshPath();
        yield return new WaitForEndOfFrame();
        NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path);
        onComplete?.Invoke(path);
    }
}
