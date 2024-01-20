using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class WapointEditor : MonoBehaviour
{

    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(Waypoint waypoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow * 0.5f;
        }

        Gizmos.DrawSphere(waypoint.transform.position, -0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.width / 2f), waypoint.transform.position - (waypoint.transform.right * waypoint.width / 2f));

        if(waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offset = waypoint.transform.right * waypoint.width / 2f;
            Vector3 offsetTo = waypoint.previousWaypoint.transform.right * waypoint.previousWaypoint.width / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + offsetTo);
        }

        if(waypoint.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = waypoint.transform.right * -waypoint.width / 2f;
            Vector3 offsetTo = waypoint.nextWaypoint.transform.right * -waypoint.nextWaypoint.width / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.nextWaypoint.transform.position + offsetTo);
        }

        if(waypoint.branches != null)
        {
            foreach(Waypoint branch in waypoint.branches)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(waypoint.transform.position, branch.transform.position);
            }
        }
    }
}
