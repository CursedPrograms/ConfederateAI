using UnityEngine;

[DisallowMultipleComponent]
public class AIRagdoll : MonoBehaviour
{
    [Tooltip("When the AI dies it will activate the Ragdoll. Make sure you set up the ragdoll; GameObject > 3D Object > Ragdoll.")]
    public bool Ragdoll = true;

    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }

    void Start()
    {
        SetKinematic(true);
    }

    public void activateRagdoll()
    {
        if (Ragdoll)
        {
            SetKinematic(false);
        }
    }
}
