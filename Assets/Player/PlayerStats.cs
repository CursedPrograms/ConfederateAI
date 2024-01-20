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
        public float healthMulti = 0.5f;

        public bool isDead;

        void Awake()
        {
            core = GetComponent<PlayerCore>();
        }

        void Start()
        {
            Health = MaxHealth;
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
            }
        }

        IEnumerator Death()
        {
            isDead = true;
            yield return new WaitForSeconds(5);
        }
    }
}
