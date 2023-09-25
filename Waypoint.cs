using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Waypoint : MonoBehaviour
{
    public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;

    [Range(0f, 0.5f)]
    public float width;

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
