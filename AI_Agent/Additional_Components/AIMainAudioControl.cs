using UnityEngine;

[DisallowMultipleComponent]
public class AIMainAudioControl : MonoBehaviour
{
    public AIAudioControl AIaudio;
    chooseAudioArray aaiAudio;

    void Start()
    {
    AIaudio = GetComponentInChildren<AIAudioControl>();
    }

    public void TargetHit()
    { if (AIaudio.canPlayAudio)
        {
            
        }
    }
}
