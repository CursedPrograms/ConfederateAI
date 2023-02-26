using UnityEditor;
using UnityEngine;

public class WayPointManagerWindow : EditorWindow {

    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<WayPointManagerWindow>();
    }

    public Transform waypointRoot;

    void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));
        if (waypointRoot == null)
        {
            EditorGUILayout.HelpBox("Root transform must be selected", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();
    }  

    void DrawButtons()
    {
        if (GUILayout.Button("CreateWaypoint"))
        {
            CreateWaypoint();
        }
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            if (GUILayout.Button("Add Branch"))
            {
                CreateBranch();
            }
            if (GUILayout.Button("Create Before"))
            {
                CreateBefore();
            }
            if (GUILayout.Button("Create After"))
            {
                CreateAfter();
            }
            if (GUILayout.Button("Remove"))
            {
                RemoveWaypoint();
            }
        }
    }

  void  CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("go_waypoint" + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);
        waypointObject.tag = "PathWaypoint";
        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
        if(waypointRoot.childCount > 1)
        {
            waypoint.previousWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<Waypoint>();
            waypoint.previousWaypoint.nextWaypoint = waypoint;
            waypoint.width = 0.5f;
            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }
        Selection.activeGameObject = waypoint.gameObject;
    }

    void CreateBefore()
    {
        GameObject waypointObject = new GameObject("go_waypoint" + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);
        waypointObject.tag = "PathWaypoint";
        Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        newWaypoint.width = 0.5f;
        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;
        if(selectedWaypoint.previousWaypoint != null)
        {
            newWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
            selectedWaypoint.previousWaypoint.nextWaypoint = newWaypoint;
        }
        newWaypoint.nextWaypoint = selectedWaypoint;
        selectedWaypoint.previousWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;
    }

    void CreateAfter()
    {
        GameObject waypointObject = new GameObject("go_waypoint" + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);
        waypointObject.tag = "PathWaypoint";
        Waypoint newWaypoint = waypointObject.GetComponent<Waypoint>();
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        newWaypoint.width = 0.5f;
        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;
        newWaypoint.previousWaypoint = selectedWaypoint;
        if (selectedWaypoint.previousWaypoint != null)
        {            
            selectedWaypoint.nextWaypoint.previousWaypoint = newWaypoint;
            newWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
        }
        selectedWaypoint.nextWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newWaypoint.gameObject;
    }

    void RemoveWaypoint()
    {
        Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        if(selectedWaypoint.nextWaypoint != null)
        {
            selectedWaypoint.nextWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
        }
        if(selectedWaypoint.previousWaypoint != null)
        {
            selectedWaypoint.previousWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
            Selection.activeGameObject = selectedWaypoint.previousWaypoint.gameObject;
        }
        DestroyImmediate(selectedWaypoint.gameObject);
    }

    void CreateBranch()
    {
        GameObject waypointObject = new GameObject("go_waypoint" + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);
        waypointObject.tag = "PathWaypoint";
        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
		waypoint.width = 0.5f;
        Waypoint bracnhedFrom = Selection.activeGameObject.GetComponent<Waypoint>();
        bracnhedFrom.branches.Add(waypoint);
        waypoint.transform.position = bracnhedFrom.transform.position;
        waypoint.transform.forward = bracnhedFrom.transform.forward;
        Selection.activeGameObject = waypoint.gameObject;
    }
}
