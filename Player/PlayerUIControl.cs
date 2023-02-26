using UnityEngine;
using UnityEngine.UI;

namespace ThirdPersonControl
{
    [DisallowMultipleComponent]
    public class PlayerUIControl : MonoBehaviour
    {
        PlayerCore core;

        public GameObject CrossHair;
        public Slider healthUI;
        public Slider staminaUI;
        public Text ammoUI;

        public GameObject DeathUI;
        public GameObject uiPanel;
        public GameObject lowUIPanel;
        public GameObject mainUI;

        void Awake()
        {
            core = GetComponent<PlayerCore>();
        }

        void Start()
        {

        }

        void Update()
        {
            healthUI.value = core.stats.Health;
        }
    }
}
