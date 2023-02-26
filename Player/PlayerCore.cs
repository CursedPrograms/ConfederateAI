using UnityEngine;

namespace ThirdPersonControl
{
    [DisallowMultipleComponent]
    public class PlayerCore : MonoBehaviour
    {
        public GameObject gameController;

        public PlayerStats stats;
        public CharacterController characterController;
        public BasicRigidBodyPush rigidBodyPush;
        public PlayerUIControl uiControl;
        public Animator animator;

        void Awake()
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");

            stats = GetComponent<PlayerStats>();
            characterController = GetComponent<CharacterController>();
            rigidBodyPush = GetComponent<BasicRigidBodyPush>();
            uiControl = GetComponent<PlayerUIControl>();
            animator = GetComponent<Animator>();
        }
    }
}
