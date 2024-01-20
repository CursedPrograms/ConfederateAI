using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class GlobalTracker : MonoBehaviour
{
    [Header("Allies - Auto Assigned")]
    [Tooltip("Do not assign anything here.")]
    public List<Transform> allies;
    [Header("Enemies - Auto Assigned")]
    [Tooltip("Do not assign anything here.")]
    public List<Transform> enemies;
    GameObject player;
    [Space]
    [Header("Update System")]
    [Tooltip("Not recommended!")]
    public bool ConstantUpdate = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
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
