using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class AIAudioControl : MonoBehaviour
{
    public bool canPlayAudio;
    Rigidbody m_Rigidbody;
    SphereCollider col;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    void Start()
    {
        m_Rigidbody.useGravity = false;
        col.isTrigger = true;
        canPlayAudio = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { canPlayAudio = true; }
        return;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { canPlayAudio = false; }
    }
}
