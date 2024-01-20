using UnityEngine;
using UnityEngine.UI;

namespace ThirdPersonControl
{
    [DisallowMultipleComponent]
    public class PlayerUIControl : MonoBehaviour
    {
        public Slider healthUI;

        void Update()
        {
            healthUI.value = GetComponent<PlayerStats>().Health;
        }
    }
}
