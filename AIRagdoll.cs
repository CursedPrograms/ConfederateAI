using UnityEngine;

[DisallowMultipleComponent]
public class AIRagdoll : MonoBehaviour
{
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
        SetKinematic(false);
    }
}
