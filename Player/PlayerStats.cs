using UnityEngine;
using UnityEngine.Video;
using System.Collections;

namespace ThirdPersonControl
{
    [DisallowMultipleComponent]
    public class PlayerStats : MonoBehaviour
    {
        PlayerCore core;

        public float Health = 100;
        public float MaxHealth = 100;
        public float healthMulti;

        public float stamina = 100;
        public float maxStamina = 100;

        public bool isDead;

        void Awake()
        {
            core = GetComponent<PlayerCore>();
        }

        void Start()
        {
            Health = MaxHealth;
            stamina = maxStamina;
        }

        void Update()
        {
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            else
            {
                if (Health <= 0)
                {
                    StartCoroutine("Death");
                }

                if (stamina < 0)
                {
                    stamina = 0;
                }

                if (stamina >= maxStamina)
                {
                    stamina = maxStamina;
                }
                else
                {
                    stamina += 0.5f * Time.deltaTime;
                }
            }
        }

        IEnumerator Death()
        {
            isDead = true;
            core.characterController.enabled = false;
            core.rigidBodyPush.enabled = false;
            core.animator.SetLayerWeight(1, Mathf.Lerp(core.animator.GetLayerWeight(1), 0f, Time.deltaTime * 13f));
            core.animator.SetTrigger("Death");
            core.uiControl.mainUI.SetActive(false);
            core.uiControl.DeathUI.SetActive(true);
            core.uiControl.DeathUI.GetComponent<VideoPlayer>().Play();
            GlobalTracker tracker = core.gameController.GetComponent<GlobalTracker>();
            if (!tracker.ConstantUpdate)
            {
                tracker.allies.Remove(gameObject.transform);
            }
            yield return new WaitForSeconds(5);
        }
    }
}
