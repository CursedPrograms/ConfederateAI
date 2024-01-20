using UnityEngine;

namespace ThirdPersonControl
{
    [DisallowMultipleComponent]
    public class PlayerCore : MonoBehaviour
    {
        public GameObject gameController;

        public PlayerStats stats;
        //   public CharacterInputs Inputs;
        public CharacterController characterController;
        public BasicRigidBodyPush rigidBodyPush;
        //  public ThirdPersonController thirdPersonController;
        //  public ThirdPersonShooterController thirdPersonShooterController;
        public PlayerUIControl uiControl;
        public Animator animator;

        void Awake()
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");

            stats = GetComponent<PlayerStats>();
            //   Inputs = GetComponent<CharacterInputs>();
            characterController = GetComponent<CharacterController>();
            rigidBodyPush = GetComponent<BasicRigidBodyPush>();
            //  thirdPersonController = GetComponent<ThirdPersonController>();
            //   thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();
            uiControl = GetComponent<PlayerUIControl>();
            animator = GetComponent<Animator>();
        }
    }
}
