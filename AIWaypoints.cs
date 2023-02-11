using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class AIWaypoints : MonoBehaviour
{
    public GameObject[] allyWaypoints;
    public GameObject[] enemywaypoints;

    public List<Transform> pathWaypoints;

    void Awake()
    {
        allyWaypoints = GameObject.FindGameObjectsWithTag("AllyWaypoint");
        enemywaypoints = GameObject.FindGameObjectsWithTag("EnemyWaypoint");

        pathWaypoints = new List<Transform>();
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("PathWaypoint");
        foreach (GameObject go in objectsWithTag)
        {
            pathWaypoints.Add(go.transform);
        }
    }
}
