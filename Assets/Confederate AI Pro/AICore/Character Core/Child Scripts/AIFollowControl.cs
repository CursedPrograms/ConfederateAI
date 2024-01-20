using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class AIFollowControl : MonoBehaviour
{
    AICore core;

    Rigidbody rigidBody;
    SphereCollider col;

    public bool isFollower;
    public bool isFollowing;

    void Start()
    {
        core = GetComponentInParent<AICore>();

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.useGravity = false;

        col = GetComponent<SphereCollider>();
        col.isTrigger = true;

        if(core.faction.Faction == 1)
        {
            isFollower = false;
        }
    }

    void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            CheckInput();
        }
    }

    void CheckInput()
    {
        if (Input.GetButton("Action") && isFollower == true)
        {
            if (isFollowing == false)
            {
                isFollowing = true;
            }
        }
        else if (Input.GetButton("Reset") && isFollower == true)
        {
            if (isFollowing == true)
            {
                isFollowing = false;
            }
        }
    }
}
