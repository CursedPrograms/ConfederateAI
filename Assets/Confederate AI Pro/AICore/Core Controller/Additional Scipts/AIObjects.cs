using UnityEngine;

[DisallowMultipleComponent]
public class AIObjects : MonoBehaviour
{
    [Header("Blood")]
    [Tooltip("Add a particle system of blood spatter.")]
    public GameObject bloodSpatter;
    [Tooltip("Add a particle system of a blood pool.")]
    public GameObject bloodpool;
    [Space]
    [Header("Loot (Not yet implemented)")]
    [Tooltip("Not yet implemented.")]
    public GameObject loot;
}
