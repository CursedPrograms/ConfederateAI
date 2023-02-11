using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class AIClothingControl : MonoBehaviour
{
    public List<GameObject> Clothing;
    public bool canGetNaked;
    public bool startNaked;

    void Start()
    {
        if (startNaked)
        {
            Undress();
        }
    }

    public void Undress()
    {
        foreach (GameObject obj in Clothing)
        {
            //Use Controller to Player Sounds
            obj.SetActive(false);
        }
    }

    public void Dress()
    {
        foreach (GameObject obj in Clothing)
        {
            //Use Controller to Player Sounds
            obj.SetActive(true);
        }
    }
}
