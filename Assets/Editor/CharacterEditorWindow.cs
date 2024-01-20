using UnityEngine;
using UnityEditor;

public class CharacterEditorWindow : EditorWindow
{
    [MenuItem("Tools/Confederate AI/Character Editor")]

    public static void Open()
    {
        GetWindow<CharacterEditorWindow>();
    }

    Vector2 scrollPosition = Vector2.zero;

    public GameObject CurrentCharacter;

    public int Faction;

    public bool followPath;
    public bool hasRandomMovement = false;
    public Transform patrolTarget = null;

    public int rotSpeed = 1;
    public float maxDistance = 1;

    public float walkSpeed = 1f;
    public bool randomWalkSpeed = false;
    public float runSpeed = 2f;
    public bool randomRunSpeed = false;
    public int maxHealth = 100;
    public float Health = 100f;
    public float healthRegen = 3f;
    public float stamina = 100f;
    public int maxStamina = 100;
    public float staminaRegen = 1f;
    public float patrolTimer = 200f;
    public float patrolWaitTime = 30f;
    public int level = 1;
    public int maxLevel = 25;
    public int levelProg = 0;
    public int levelProgMax = 2;
    public int Sight = 20;
    public int damage = 5;
    public bool canRegen = true;
    public bool randomLoot = true;
    public bool instantiateBlood = true;

    public bool ragdoll = true;

    public bool destroyComponents;

    void OnGUI()
    {

        EditorGUILayout.BeginVertical("box");

        GUILayout.Label("Character Editor", EditorStyles.boldLabel);

        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("CurrentCharacter"));


        if (CurrentCharacter == null)
        {
            EditorGUILayout.BeginVertical("box");
            GUI.backgroundColor = Color.yellow;
            EditorGUILayout.HelpBox("Select a character to edit", MessageType.Info);
            EditorGUILayout.EndVertical();
        }
        else
        {
            if (!CurrentCharacter.GetComponent<AICore>())
            {
                EditorGUILayout.BeginVertical("box");
                GUI.backgroundColor = Color.red;
                EditorGUILayout.HelpBox("This object does not have an AICore component!", MessageType.Warning);
                EditorGUILayout.EndVertical();
            }
            else
            {
                EditorGUILayout.BeginVertical("box");
                scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true, GUILayout.Width(400), GUILayout.Height(500));
               

                GUILayout.Space(5f);
                GUILayout.Label("Faction", EditorStyles.label);

                Faction = EditorGUILayout.IntSlider(Faction, 0, 1);
                CurrentCharacter.GetComponent<AIFactionControl>().Faction = Faction;

                if (Faction == 0)
                {
                    GUI.backgroundColor = Color.blue;
                    GUILayout.Label("Current Faction: Ally", EditorStyles.label);
                }
                else
                {
                    GUI.backgroundColor = Color.red;
                    GUILayout.Label("Current Faction: Enemy", EditorStyles.label);
                }

                GUILayout.Space(5f);

                followPath = GUILayout.Toggle(followPath, "Follow Path");
                CurrentCharacter.GetComponent<AILogic>().followPath = followPath;

                hasRandomMovement = GUILayout.Toggle(hasRandomMovement, "Has Random Movement");
                CurrentCharacter.GetComponent<AILogic>().hasRandomMovement = hasRandomMovement;

                GUILayout.Space(5f);
                GUILayout.Label("Speed", EditorStyles.label);

                randomWalkSpeed = GUILayout.Toggle(randomWalkSpeed, "Random Walk Speed");
                CurrentCharacter.GetComponent<AIStats>().randomWalkSpeed = randomWalkSpeed;

                if (!randomWalkSpeed)
                {
                    walkSpeed = EditorGUILayout.Slider(walkSpeed, 1, 2.9f);
                    CurrentCharacter.GetComponent<AIStats>().walkSpeed = walkSpeed;
                }

                randomRunSpeed = GUILayout.Toggle(randomRunSpeed, "Random Run Speed");
                CurrentCharacter.GetComponent<AIStats>().randomRunSpeed = randomRunSpeed;

                if (!randomRunSpeed)
                {
                    runSpeed = EditorGUILayout.Slider(runSpeed, 3, 6);
                    CurrentCharacter.GetComponent<AIStats>().runSpeed = runSpeed;
                }

                GUILayout.Space(5f);
                GUILayout.Label("Health", EditorStyles.label);

                Health = EditorGUILayout.FloatField("Health:", Health);
                CurrentCharacter.GetComponent<AIStats>().Health = Health;

                maxHealth = EditorGUILayout.IntField("Max Health:", maxHealth);
                CurrentCharacter.GetComponent<AIStats>().maxHealth = maxHealth;

                healthRegen = EditorGUILayout.FloatField("Health Regen:", healthRegen);
                CurrentCharacter.GetComponent<AIStats>().healthRegen = healthRegen;

                GUILayout.Space(5f);
                GUILayout.Label("Stamina", EditorStyles.label);

                stamina = EditorGUILayout.FloatField("Stamina:", stamina);
                CurrentCharacter.GetComponent<AIStats>().stamina = stamina;

                maxStamina = EditorGUILayout.IntField("Max Stamina:", maxStamina);
                CurrentCharacter.GetComponent<AIStats>().maxStamina = maxStamina;

                staminaRegen = EditorGUILayout.FloatField("Stamina Regen:", staminaRegen);
                CurrentCharacter.GetComponent<AIStats>().staminaRegen = staminaRegen;

                canRegen = GUILayout.Toggle(canRegen, "Can Regenerate (Health & Stamina)");
                CurrentCharacter.GetComponent<AIStats>().canRegen = canRegen;

                GUILayout.Space(5f);
                GUILayout.Label("Patrol Timers", EditorStyles.label);

                patrolTimer = EditorGUILayout.FloatField("Patrol Timer:", patrolTimer);
                CurrentCharacter.GetComponent<AIStats>().patrolTimer = patrolTimer;

                patrolWaitTime = EditorGUILayout.FloatField("Patrol Wait Time:", patrolWaitTime);
                CurrentCharacter.GetComponent<AIStats>().patrolWaitTime = patrolWaitTime;

                level = EditorGUILayout.IntField("Level:", level);
                CurrentCharacter.GetComponent<AIStats>().level = level;

                maxLevel = EditorGUILayout.IntField("Max Level:", maxLevel);
                CurrentCharacter.GetComponent<AIStats>().maxLevel = maxLevel;

                Sight = EditorGUILayout.IntField("Sight:", Sight);
                CurrentCharacter.GetComponent<AIStats>().Sight = Sight;

                damage = EditorGUILayout.IntField("Damage:", damage);
                CurrentCharacter.GetComponent<AIStats>().damage = damage;

                randomLoot = GUILayout.Toggle(randomLoot, "Random Loot: (Not Implemented!)");
                CurrentCharacter.GetComponent<AIStats>().randomLoot = randomLoot;

                instantiateBlood = GUILayout.Toggle(instantiateBlood, "Instantiate Blood");
                CurrentCharacter.GetComponent<AIStats>().instantiateBlood = instantiateBlood;

                ragdoll = GUILayout.Toggle(ragdoll, "Ragdoll");
                CurrentCharacter.GetComponent<AIRagdoll>().Ragdoll = ragdoll;

                destroyComponents = GUILayout.Toggle(destroyComponents, "Destroy Components");
                CurrentCharacter.GetComponent<AIDeactivateComponents>().destroyComponents = destroyComponents; ;

                GUILayout.Space(5f);

                GUI.backgroundColor = Color.green;

                if (GUILayout.Button("Character Debugger"))
                {
                    CharacterDebuggerWindow DebugWindow = GetWindow<CharacterDebuggerWindow>();
                    DebugWindow.CurrentCharacter = CurrentCharacter;
                }

                GUI.backgroundColor = Color.red;

                if (GUILayout.Button("Character Cleaner"))
                {
                    CharacterCleanerWindow CleanerWindow = GetWindow<CharacterCleanerWindow>();
                    CleanerWindow.CurrentCharacter = CurrentCharacter;
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
        }

        GUILayout.EndScrollView();
        GUILayout.Label("AI by Cursed Entertainment", EditorStyles.boldLabel);
        obj.ApplyModifiedProperties();
    }
}
