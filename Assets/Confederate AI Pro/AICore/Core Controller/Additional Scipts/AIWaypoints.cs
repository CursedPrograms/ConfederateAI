using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class AIWaypoints : MonoBehaviour
{
    [Header("Ally Waypoints - Auto Assigned")]
    [Tooltip("Do not assign anything here.")]
    public GameObject[] allyWaypoints;
    [Header("Enemy Waypoints - Auto Assigned")]
    [Tooltip("Do not assign anything here.")]
    public GameObject[] enemywaypoints;
    [Header("Path Waypoints - Auto Assigned")]
    [Tooltip("Do not assign anything here.")]
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
