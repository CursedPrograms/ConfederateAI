using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Waypoint : MonoBehaviour
{
    [Header("Waypoints")]
    [Tooltip("Previous Waypoint, can also be dragged and dropped.")]
    public Waypoint previousWaypoint;
    [Tooltip("Next Waypoint, can also be dragged and dropped.")]
    public Waypoint nextWaypoint;
    [Space]
    [Header("Width")]
    [Range(0f, 0.5f)]
    public float width;
    [Space]
    [Header("Branches")]
    public List<Waypoint> branches;
    [Range(0f, 1f)]
    public float branchRatio = 0.5f;

    public Vector3 GetPosition()
    {
        Vector3 MinBound = transform.position + transform.right * width / 2f;
        Vector3 MaxBound = transform.position - transform.right * width / 2f;

        return Vector3.Lerp(MinBound, MaxBound, Random.Range(0f, 1f));
    }
}
