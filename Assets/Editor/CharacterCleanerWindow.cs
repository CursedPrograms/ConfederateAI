using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class CharacterCleanerWindow : EditorWindow
{
    [MenuItem("Tools/Confederate AI/Character Cleaner")]

    public static void Open()
    {
        GetWindow<CharacterCleanerWindow>();
    }

    public GameObject CurrentCharacter;

    public bool removeNavMesh = true;

    void OnGUI()
    {
        EditorGUILayout.BeginVertical("box");

        GUILayout.Label("Character Cleaner", EditorStyles.boldLabel);      

        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("CurrentCharacter"));
        if (CurrentCharacter == null)
        {
            GUI.backgroundColor = Color.yellow;
            EditorGUILayout.HelpBox("Select a character to clean, this will remove all AI components", MessageType.Info);
        }
        else
        {
            if (!CurrentCharacter.GetComponent<AICore>())
            {
                GUI.backgroundColor = Color.red;
                EditorGUILayout.HelpBox("This object does not have an AICore component!", MessageType.Warning);
                GUI.backgroundColor = Color.green;
                if (GUILayout.Button("AI Creator"))
                {
                    AICreatorWindow EditorWindow = GetWindow<AICreatorWindow>();
                    EditorWindow.EmptyCharacter = CurrentCharacter;
                    CurrentCharacter = null;
                }
            }
            else
            {
                GUI.backgroundColor = Color.red;

                if (GUILayout.Button("Remove AI"))
                {
                    DestroyImmediate(CurrentCharacter.GetComponent<AICore>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIAnimator>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIAttack>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIDeactivateComponents>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIDeath>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIFactionControl>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AILevelController>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AILogic>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIMainAudioControl>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIMovement>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIRagdoll>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AISave>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AIStats>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AITargetting>());

                    if (removeNavMesh)
                    {
                        DestroyImmediate(CurrentCharacter.GetComponent<NavMeshAgent>());
                    }

                    DestroyImmediate(CurrentCharacter.GetComponent<NavMeshObstacle>());
                    DestroyImmediate(CurrentCharacter.GetComponent<AudioSource>());
                    CurrentCharacter.GetComponentInChildren<AIAudioControl>().gameObject.SetActive(false);
                    CurrentCharacter.GetComponentInChildren<AIFollowControl>().gameObject.SetActive(false);
                }

                removeNavMesh = GUILayout.Toggle(removeNavMesh, "Remove Navmesh Agent");
            }
        }
        EditorGUILayout.EndVertical();

        GUILayout.Label("AI by Cursed Entertainment", EditorStyles.boldLabel);

        obj.ApplyModifiedProperties();
    }
}
