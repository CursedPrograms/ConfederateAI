using UnityEngine;
using UnityEditor;

public class CharacterDebuggerWindow : EditorWindow
{
    [MenuItem("Tools/Confederate AI/Character Debugger")]

    public static void Open()
    {
        GetWindow<CharacterDebuggerWindow>();
    }

    public GameObject CurrentCharacter;

    Vector2 scrollPosition = Vector2.zero;

    void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true, GUILayout.Width(400), GUILayout.Height(500));
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("Character Debugger", EditorStyles.boldLabel);

        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("CurrentCharacter"));
        if (CurrentCharacter == null)
        {
            GUI.backgroundColor = Color.yellow;
            EditorGUILayout.HelpBox("Select A Character", MessageType.Info);
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

                Animator animator = CurrentCharacter.GetComponent<Animator>();
                if (animator != null)
                {
                    if (animator.runtimeAnimatorController == null)
                    {
                        EditorGUILayout.HelpBox("Please assign the animation controller!", MessageType.Warning);
                    }
                }
                else
                {
                    EditorGUILayout.HelpBox("This character has no animator!", MessageType.Warning);
                }

                AIMainAudioControl mainAudio = CurrentCharacter.GetComponent<AIMainAudioControl>();
                if (mainAudio != null)
                {
                    if (mainAudio.playerSightedClip == null)
                    {
                        EditorGUILayout.HelpBox("Player sighted audio clip not assigned!", MessageType.Warning);
                    }
                }

                if (!CurrentCharacter.GetComponentInChildren<AIAudioControl>())
                {
                    EditorGUILayout.HelpBox("This object does not have an AI audio control child object!", MessageType.Warning);
                }
                if (!CurrentCharacter.GetComponentInChildren<AIFollowControl>())
                {
                    EditorGUILayout.HelpBox("This object does not have an AI follow control child object!", MessageType.Warning);
                }

                GUI.backgroundColor = Color.green;

                int faction = CurrentCharacter.GetComponent<AIFactionControl>().Faction;

                if (faction == 0)
                {
                    GUILayout.Label("Current Faction: Ally" + "(*AIFaction)", EditorStyles.label);
                }
                else
                {
                    GUILayout.Label("Current Faction: Enemy" + "(*AIFaction)", EditorStyles.label);
                }

                AIAttack attack = CurrentCharacter.GetComponent<AIAttack>();
                GUILayout.Label("Attack Timer:" + attack.attackTimer + "(*AIAttack)", EditorStyles.label);

                AILogic logic = CurrentCharacter.GetComponent<AILogic>();
                GUILayout.Label("Has Random Movement:" + logic.hasRandomMovement + "(*AILogic)", EditorStyles.label);
                GUILayout.Label("Follow Path:" + logic.followPath + "(*AILogic)", EditorStyles.label);
                GUILayout.Label("Rotation Speed:" + logic.rotSpeed + "(*AILogic)", EditorStyles.label);
                GUILayout.Label("Max Distance:" + logic.maxDistance + "(*AILogic)", EditorStyles.label);

                AIStats stats = CurrentCharacter.GetComponent<AIStats>();
                GUILayout.Label("Walk Speed:" + stats.walkSpeed + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Random Walk Speed:" + stats.randomWalkSpeed + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Run Speed:" + stats.runSpeed + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Random Run Speed:" + stats.randomRunSpeed + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Max Health:" + stats.maxHealth + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Health:" + stats.Health + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Health Regen:" + stats.healthRegen + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Max Stamina:" + stats.maxStamina + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Stamina:" + stats.stamina + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Stamina Regen:" + stats.staminaRegen + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Patrol Timer:" + stats.patrolTimer + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Patrol Wait Time:" + stats.patrolWaitTime + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Sight:" + stats.Sight + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Base Damage:" + stats.damage + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Can Regen:" + stats.canRegen + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Random Loot:" + stats.randomLoot + "(NOT YET IMPLEMENTED) " + "(*AIStats)", EditorStyles.label);
                GUILayout.Label("Instantiate Blood:" + stats.instantiateBlood + "(*AIStats)", EditorStyles.label);

                AIRagdoll ragdoll = CurrentCharacter.GetComponent<AIRagdoll>();
                GUILayout.Label("Ragdoll:" + ragdoll.Ragdoll + "(*AIRagdoll)", EditorStyles.label);

                if (GUILayout.Button("Edit"))
                {
                    CharacterEditorWindow EditorWindow = GetWindow<CharacterEditorWindow>();
                    EditorWindow.CurrentCharacter = CurrentCharacter;
                }
            }
        }
        GUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
        GUILayout.Label("AI by Cursed Entertainment", EditorStyles.boldLabel);

        obj.ApplyModifiedProperties();
    }
}
