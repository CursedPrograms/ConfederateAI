using UnityEngine;

[DisallowMultipleComponent]
public class AIUniversalVariables : MonoBehaviour
{
    [Header("Universal Stats Regen Multipliers")]
    [Tooltip("How much health is restored each frame.")]
    public int LevelHealthIncrease = 5;
    [Tooltip("How much stamina is restored each frame.")]
    public int LevelStaminaIncrease = 10;
    [Header("Level")]
    [Tooltip("How much damage increases when levelling up.")]
    public int LevelDamageIncrease = 5;
    [Space]
    [Header("Universal Attack Stamina Drain Multipliers")]
    public int attack01StaminaDrain = 4;
    public int attack02StaminaDrain = 8;
    public int attack03StaminaDrain = 16;
}
