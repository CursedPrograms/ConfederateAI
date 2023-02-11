using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class GlobalTracker : MonoBehaviour
{
    public List<Transform> allies;
    public List<Transform> enemies;
    GameObject player;

    public bool ConstantUpdate = false;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        allies = new List<Transform>();
        enemies = new List<Transform>();
    }

    void Update()
    {
        if (ConstantUpdate)
        {
            allies.Clear();
            enemies.Clear();
            addAllPlayers();
        }
    }

    public void addAllPlayers()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Ally");
        GameObject[] go2 = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindWithTag("Player");

        foreach (GameObject Ally in go)
        {
            AddAllies(Ally.transform);
        }
        foreach (GameObject Enemy in go2)
        {
            AddEnemies(Enemy.transform);
        }

        if (player != null)
        {
            allies.Add(player.transform);
        }
    }

    public void AddAllies(Transform Ally)
    {
        allies.Add(Ally);
    }

    public void AddEnemies(Transform Enemy)
    {
        enemies.Add(Enemy);
    }
}
