using System.IO;
using UnityEditor;
using UnityEngine;

public class AICreatorWindow : EditorWindow
{
    [MenuItem("Tools/Confederate AI/AI Creator")]
    public static void Open()
    {
        GetWindow<AICreatorWindow>();
    }

    public GameObject EmptyCharacter;
    public GameObject spawnCharacter;

    public bool createPrefab = true;

    void OnGUI()
    {
        EditorGUILayout.BeginVertical("box");

        GUILayout.Label("AI Creator", EditorStyles.boldLabel);
        GUILayout.Label("Character Creator", EditorStyles.largeLabel);
        GUI.backgroundColor = Color.white;
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("EmptyCharacter"));
        if (EmptyCharacter == null)
        {
            GUI.backgroundColor = Color.yellow;
            EditorGUILayout.HelpBox("Empty character must be selected", MessageType.Info);
        }
        else
        {
            bool PrefabSuccess = false;

            if (!EmptyCharacter.GetComponent<AICore>())
            {
                GUI.backgroundColor = Color.green;
                createPrefab = GUILayout.Toggle(createPrefab, "Create Prefab");

                if (GUILayout.Button("Make AI"))
                {
                    EmptyCharacter.name = "Confederate Agent";
                    EmptyCharacter.AddComponent<AICore>();

                    CreateFollowControl();
                    CreateAudioControl();

                    CharacterEditorWindow EditorWindow = GetWindow<CharacterEditorWindow>();
                    EditorWindow.CurrentCharacter = EmptyCharacter;

                    if (createPrefab)
                    {
                        if (!Directory.Exists("Assets/Prefabs"))
                            AssetDatabase.CreateFolder("Assets", "Prefabs");
                        string localPath = "Assets/Prefabs/" + EmptyCharacter.name + ".prefab";
                        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
                        bool prefabSuccess;
                        PrefabUtility.SaveAsPrefabAsset(EmptyCharacter, localPath, out prefabSuccess);
                        PrefabSuccess = prefabSuccess;
                    }

                    EmptyCharacter = null;
                }
                else
                {
                    GUI.backgroundColor = Color.green;
                }

                if (createPrefab)
                {
                    GUI.backgroundColor = Color.yellow;
                    EditorGUILayout.HelpBox("Assets/Prefabs", MessageType.Info);
                }
            }

            GUI.backgroundColor = Color.yellow;
            EditorGUILayout.HelpBox("Make sure you set up the ragdoll; GameObject > 3D Object > Ragdoll.", MessageType.Info);
        }

        obj.ApplyModifiedProperties();

        GUILayout.Label("Spawner Creator", EditorStyles.largeLabel);
        GUI.backgroundColor = Color.white;
        SerializedObject obj2 = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj2.FindProperty("spawnCharacter"));
        if (spawnCharacter == null)
        {
            GUI.backgroundColor = Color.yellow;
            EditorGUILayout.HelpBox("Character must be selected", MessageType.Info);
        }
        else
        {
            if (!spawnCharacter.GetComponent<AICore>())
            {
                GUI.backgroundColor = Color.red;
                EditorGUILayout.HelpBox("This object does not have an AICore component!", MessageType.Warning);
            }
            else
            {
                GUI.backgroundColor = Color.green;
                if (GUILayout.Button("Make Spawner"))
                {
                    GameObject Spawner = new GameObject();
                    AISpawner spawner = Spawner.AddComponent<AISpawner>();
                    spawner.Character = spawnCharacter;
                    Spawner.name = "Spawner";
                }
            }
        }

        obj2.ApplyModifiedProperties();

        GUI.backgroundColor = Color.white;
        GUILayout.Label("Controller Creator", EditorStyles.largeLabel);

        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Create New Controller"))
        {
            GameObject currentGameController = GameObject.FindGameObjectWithTag("GameController");
            DestroyImmediate(currentGameController);
            GameObject gameController = new GameObject();
            gameController.name = "Game Controller";
            gameController.tag = "GameController";
            gameController.AddComponent<AIControllerCore>();
            GameObject allyFaux = new GameObject();
            allyFaux.transform.SetParent(gameController.transform);
            allyFaux.AddComponent<FauxTarget>();
            allyFaux.GetComponent<FauxTarget>().Faction = 0;
            allyFaux.name = "Ally Faux";
            GameObject enemyFaux = new GameObject();
            enemyFaux.transform.SetParent(gameController.transform);
            enemyFaux.AddComponent<FauxTarget>();
            enemyFaux.GetComponent<FauxTarget>().Faction = 1;
            enemyFaux.name = "Enemy Fuax";
        }

        GUI.backgroundColor = Color.yellow;
        EditorGUILayout.HelpBox("This will create a new game object tagged GameController", MessageType.Info);

        GUI.backgroundColor = Color.white;
        GUILayout.Label("Waypoint Manager", EditorStyles.largeLabel);

        GUI.backgroundColor = Color.cyan;
        if (GUILayout.Button("Waypoint Manager"))
        {
            GetWindow<WayPointManagerWindow>();
        }

        GUI.backgroundColor = Color.white;
        GUILayout.Label("AI by Cursed Entertainment", EditorStyles.boldLabel);

        EditorGUILayout.EndVertical();
    }

    void CreateFollowControl()
    {
        GameObject followControl = new GameObject("Follow Control");
        followControl.transform.SetParent(EmptyCharacter.transform);
        followControl.AddComponent<AIFollowControl>();
    }

    void CreateAudioControl()
    {
        GameObject followControl = new GameObject("Audio Control");
        followControl.transform.SetParent(EmptyCharacter.transform);
        followControl.AddComponent<AIAudioControl>();
    }
}
