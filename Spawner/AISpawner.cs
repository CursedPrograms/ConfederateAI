using UnityEngine;

[DisallowMultipleComponent]
public class AISpawner : MonoBehaviour
{
    public GameObject Character;

    public bool SpawnsFollower = false;
    public bool SaveValues = true;
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
