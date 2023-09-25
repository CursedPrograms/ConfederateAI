using UnityEditor;
using UnityEngine;

public class WayPointManagerWindow : EditorWindow
{
    [MenuItem("Tools/Confederate AI/Waypoint Manager")]
    public static void Open()
    {
        GetWindow<WayPointManagerWindow>();
    }

    public Transform waypointRoot;

    void OnGUI()
    {
        GUILayout.Label("Waypoint Manager", EditorStyles.boldLabel);

        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));
        if (waypointRoot == null)
        {
            GUI.backgroundColor = Color.yellow;
            EditorGUILayout.HelpBox("To create a path, a root transform must be selected or created", MessageType.Info);

            GUI.backgroundColor = Color.blue;
            if (GUILayout.Button("Create Path Root"))
            {
                GameObject enemyWaypoint = new GameObject();
                enemyWaypoint.name = "Path Root";
                waypointRoot = enemyWaypoint.transform;
            }

            GUI.backgroundColor = Color.green;

            if (GUILayout.Button("Create Enemy Waypoint"))
            {
                GameObject enemyWaypoint = new GameObject();
                enemyWaypoint.name = "Enemy Waypoint";
                enemyWaypoint.tag = "EnemyWaypoint";
            }

            GUI.backgroundColor = Color.green;

            if (GUILayout.Button("Create Ally Waypoint"))
            {
                GameObject allyWaypoint = new GameObject();
                allyWaypoint.name = "Ally Waypoint";
                allyWaypoint.tag = "AllyWaypoint";
            }
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }

        GUILayout.Label("AI by Cursed Entertainment", EditorStyles.boldLabel);

        obj.ApplyModifiedProperties();
    }

    void DrawButtons()
    {
        GUI.backgroundColor = Color.blue;
        if (GUILayout.Button("CreateWaypoint"))
        {
            CreateWaypoint();
        }
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            GUI.backgroundColor = Color.blue;
            if (GUILayout.Button("Add Branch"))
            {
                CreateBranch();
            }
            GUI.backgroundColor = Color.black;
            if (GUILayout.Button("Create Before"))
            {
                CreateBefore();
            }
            GUI.backgroundColor = Color.black;
            if (GUILayout.Button("Create After"))
            {
                CreateAfter();
            }
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("Remove"))
            {
                RemoveWaypoint();
            }

            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("Clear"))
            {
                waypointRoot = null;
            }
        }
    }

    void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("go_waypoint" + waypointRoot.childCount, typeof(Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);
        waypointObject.tag = "PathWaypoint";
        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
        if (waypointRoot.childCount > 1)
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
        if (selectedWaypoint.previousWaypoint != null)
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
        if (selectedWaypoint.nextWaypoint != null)
        {
            selectedWaypoint.nextWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
        }
        if (selectedWaypoint.previousWaypoint != null)
        {
            selectedWaypoint.previousWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
            Selection.activeGameObject = selectedWaypoint.previousWaypoint.gameObject;
        }
        DestroyImmediate(selectedWaypoint.gameObject);
    }

    void CreateBranch()
    {
        GameObject selectedObject = Selection.activeGameObject;
        if (selectedObject == null)
        {
            selectedObject = Selection.activeTransform.gameObject;
        }

        if (selectedObject != null)
        {
            GameObject waypointObject = new GameObject("go_waypoint" + waypointRoot.childCount, typeof(Waypoint));
            waypointObject.transform.SetParent(waypointRoot, false);
            Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
            Waypoint branchedFrom = selectedObject.GetComponent<Waypoint>();
            branchedFrom.branches.Add(waypoint);

            waypoint.transform.position = branchedFrom.transform.position;
            waypoint.transform.forward = branchedFrom.transform.forward;
            Selection.activeGameObject = waypoint.gameObject;

            waypointObject.tag = "PathWaypoint";
            waypoint.width = 0.5f;
        }
    }
}
