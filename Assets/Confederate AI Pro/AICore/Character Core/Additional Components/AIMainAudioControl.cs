using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class AIMainAudioControl : MonoBehaviour
{
    [HideInInspector]
    public AIAudioControl AIaudio;

    [Header("Clips")]
    [SerializeField]
    AudioClip[] attackClips;
    [SerializeField]
    AudioClip[] hitClips;
    public AudioClip playerSightedClip;

    AudioSource soundSource;

    void Start()
    {
        soundSource = GetComponent<AudioSource>();

        if (AIaudio == null)
        {
            AIaudio = GetComponentInChildren<AIAudioControl>();
        }
    }

    public void Attack()
    {
        if (AIaudio.canPlayAudio)
        {
            randomHit();
        }
    }

    void randomAttack()
    {
        AudioClip clip = GetRandomAttack();
        soundSource.PlayOneShot(clip);
    }

    AudioClip GetRandomAttack()
    {
        return attackClips[Random.Range(0, attackClips.Length)];
    }

    public void TargetHit()
    {
        if (AIaudio.canPlayAudio)
        {
            randomHit();
        }
    }  

    void randomHit()
    {
        AudioClip clip = GetRandomHit();
        soundSource.PlayOneShot(clip);
    }

    AudioClip GetRandomHit()
    {
        return hitClips[Random.Range(0, hitClips.Length)];
    }

    public void playerSighted()
    {
        if (playerSightedClip != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = playerSightedClip;
            audioSource.Play();
        }
    }
}
