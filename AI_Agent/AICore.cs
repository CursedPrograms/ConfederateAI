using UnityEngine;
using UnityEngine.AI;

[AddComponentMenu("AI")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AIAnimator))]
[RequireComponent(typeof(AIAttack))]
[RequireComponent(typeof(AIClothingControl))]
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
[DisallowMultipleComponent]
public class AICore : MonoBehaviour
{
    public GameObject gameController;
    public GlobalTracker tracker;
    public AIWaypoints waypoints;
    public AIObjects objects;
    public AIUniversalVariables variables;

    public AIAttack attack;
    public AIDeath death;
    public AIFactionControl faction;
    public AISave save;
    public AIStats stats;
    public AIMovement movement;
    public AIFollowControl follow;
    public AIAnimator animator;
    public AIDeactivateComponents deactivator;
    public AITargetting targetting;
    public AIRagdoll ragdoll;
    public AILogic logic;
    public AIClothingControl clothing;
    public AIMainAudioControl Audio;
    public AILevelController level;

    public NavMeshAgent navAgent;
    public NavMeshObstacle navObstacle;

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
        clothing = GetComponent<AIClothingControl>();
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
