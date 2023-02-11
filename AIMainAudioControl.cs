using UnityEngine;

[DisallowMultipleComponent]
public class AIMainAudioControl : MonoBehaviour
{
    public AIAudioControl AIaudio;
    chooseAudioArray aaiAudio;

    void Start()
    {
    //    aaiAudio = GameObject.FindWithTag("GameController").GetComponent<AudioArrayKeeper>().aaiAudio;
     //   AIaudio = GetComponentInChildren<AIAudioControl>();
    }

    public void TargetHit()
    {
      /*  if (AIaudio.canPlayAudio)
        {
            aaiAudio.playRandom();
        }*/
    }
}
