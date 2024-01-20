using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("Confederate AI/AI")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AIAnimator))]
[RequireComponent(typeof(AIAttack))]
[RequireComponent(typeof(AIFactionControl))]
[RequireComponent(typeof(AIMainAudioControl))]
[RequireComponent(typeof(AILogic))]
[RequireComponent(typeof(AIMovement))]
[RequireComponent(typeof(AISave))]
[RequireComponent(typeof(AIStats))]
[RequireComponent(typeof(AITargetting))]
[RequireComponent(typeof(AIDeactivateComponents))]
[RequireComponent(typeof(AIRagdoll))]
[RequireComponent(typeof(AIDeath))]
[RequireComponent(typeof(AILevelController))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(NavMeshObstacle))]
[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]
public class AICore : MonoBehaviour
{
    [HideInInspector]
    public GameObject gameController;
    [HideInInspector]
    public GlobalTracker tracker;
    [HideInInspector]
    public AIWaypoints waypoints;
    [HideInInspector]
    public AIObjects objects;
    [HideInInspector]
    public AIUniversalVariables variables;
    [HideInInspector]
    public AIAttack attack;
    [HideInInspector]
    public AIDeath death;
    [HideInInspector]
    public AIFactionControl faction;
    [HideInInspector]
    public AISave save;
    [HideInInspector]
    public AIStats stats;
    [HideInInspector]
    public AIMovement movement;
    [HideInInspector]
    public AIFollowControl follow;
    [HideInInspector]
    public AIAnimator animator;
    [HideInInspector]
    public AIDeactivateComponents deactivator;
    [HideInInspector]
    public AITargetting targetting;
    [HideInInspector]
    public AIRagdoll ragdoll;
    [HideInInspector]
    public AILogic logic;
    [HideInInspector]
    public AIMainAudioControl Audio;
    [HideInInspector]
    public AILevelController level;
    [HideInInspector]
    public NavMeshAgent navAgent;
    [HideInInspector]
    public NavMeshObstacle navObstacle;
    [HideInInspector]
    public bool instaDeath = false;

    void Awake()
    {
        gameController = GameObject.FindWithTag("GameController");

        tracker = gameController.GetComponent<GlobalTracker>();
        waypoints = gameController.GetComponent<AIWaypoints>();
        objects = gameController.GetComponent<AIObjects>();
        variables = gameController.GetComponent<AIUniversalVariables>();

        logic = GetComponent<AILogic>();
        attack = GetComponent<AIAttack>();
        faction = GetComponent<AIFactionControl>();
        stats = GetComponent<AIStats>();
        save = GetComponent<AISave>();
        movement = GetComponent<AIMovement>();
        follow = GetComponentInChildren<AIFollowControl>();
        animator = GetComponent<AIAnimator>();
        deactivator = GetComponent<AIDeactivateComponents>();
        ragdoll = GetComponent<AIRagdoll>();
        Audio = GetComponent<AIMainAudioControl>();
        level = GetComponent<AILevelController>();
        targetting = GetComponent<AITargetting>();
        death = GetComponent<AIDeath>();

        navAgent = GetComponent<NavMeshAgent>();
        navObstacle = GetComponent<NavMeshObstacle>();
    }

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
    }
}
