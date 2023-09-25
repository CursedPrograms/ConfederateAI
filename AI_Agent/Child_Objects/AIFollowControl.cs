using UnityEngine;
using UnityEngine.UI;

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

    GameObject textField;
    string Ask;
    string Dismiss;

    void Start()
    {
        core = GetComponentInParent<AICore>();

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.useGravity = false;

        col = GetComponent<SphereCollider>();
        col.isTrigger = true;

      //  textField = core.gameController.GetComponentInParent<UIKeeper>().actionUI;
      //  textField.SetActive(false);  

        if(core.faction.Faction == 1)
        {
            isFollower = false;
        }

        Ask = "Press Action To Ask Follower";
        Dismiss = "Press Reset To Dismiss Follower";
    }

    void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            CheckUI();
            CheckInput();
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            textField.SetActive(false);
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

    void CheckUI()
    {
        if (isFollower == true)
        {
            if (isFollowing)
            {
                textField.GetComponent<Text>().text = Dismiss;
                textField.SetActive(true);
            }
            else if (!isFollowing)
            {
                textField.GetComponent<Text>().text = Ask;
                textField.SetActive(true);
            }
        }
    }   
}
