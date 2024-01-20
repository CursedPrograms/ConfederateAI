using UnityEngine;

[DisallowMultipleComponent]
[AddComponentMenu("Confederate AI/AISpawner")]
public class AISpawner : MonoBehaviour
{    
    [Tooltip("The character to spawn. Select a prefab from the project window/not the hierarchy window.")]
    public GameObject Character;
    [Tooltip("Ignores logic and follows player. Recommended on Ally AI - Simulates a campanion.")]
    public bool SpawnsFollower = false;
    [Tooltip("Not yet implemented.")]
    public bool SaveValues = true;
    [Tooltip("Respawns character after death.")]
    public bool respawn = true;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject CurrentCharacter;

        CurrentCharacter = Instantiate(Character, transform.position, transform.rotation);
        AICore core = CurrentCharacter.GetComponent<AICore>();
        core.logic.hasRandomMovement = true;       

        if (SpawnsFollower)
        {
            core.follow.isFollower = true;
            core.follow.isFollowing = true;
        }

        if (SaveValues)
        {

        }

        if (respawn)
        {
            core.stats.isSpawned = true;
            core.stats.spawner = this;
        }
        else
        {

        }
    }
}
