using UnityEngine;

[DisallowMultipleComponent]
public class AIDeactivateComponents : MonoBehaviour
{
    AICore core;

    public bool destroyComponents = true;

    void Start()
    {
        core = GetComponent<AICore>();
    }

    public void DestroyComponents()
    {
        AIAnimator animator = core.animator;
        AIAttack attack = core.attack;
        AILogic logic = core.logic;
        AIFactionControl faction = core.faction;
        AIFollowControl follow = core.follow;
        AILevelController level = core.level;
        AIMainAudioControl Audio = core.Audio;
        AIMovement movement = core.movement;
        AIRagdoll ragdoll = core.ragdoll;
        AISave save = core.save;
        AIStats stats = core.stats;
        AITargetting targetting = core.targetting;

     //   GameObject AIaudio = core.Audio.AIaudio.gameObject;

        core.navAgent.enabled = false;

        if (destroyComponents)
        {
            Destroy(core);

        //    Destroy(AIaudio);

            Destroy(animator);
            Destroy(attack);
            Destroy(logic);
            Destroy(faction);
            Destroy(follow);
            Destroy(logic);
            Destroy(level);
            Destroy(Audio);            
            Destroy(movement);
            Destroy(ragdoll);
            Destroy(save);
            Destroy(stats);
            Destroy(targetting);

            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<AudioSource>());
            Destroy(this);
        }
        else
        {
            core.navAgent.enabled = false;
            core.enabled = false;

        //    AIaudio.SetActive(false);
        //    AIaudio.SetActive(false);

            animator.enabled = false;
            attack.enabled = false;
            logic.enabled = false;
            faction.enabled = false;
            follow.enabled = false;
            logic.enabled = false;
            level.enabled = false;
            Audio.enabled = false;            
            movement.enabled = false;
            ragdoll.enabled = false;
            save.enabled = false;
            stats.enabled = false;
            targetting.enabled = false;

            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<AudioSource>().enabled = false;

            enabled = false;
        }
    }
}
