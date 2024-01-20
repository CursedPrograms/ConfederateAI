using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class AITargetting : MonoBehaviour
{
    AICore core;
    List<Transform> targets;
    Transform selectedTarget;
    Transform myTransform;

    void Start()
    {
        core = GetComponent<AICore>();
        targets = new List<Transform>();
        selectedTarget = null;
        myTransform = transform;

        AssignToTracker();
    }

    void Update()
    {
        DeselectTarget();
        AddAllEnemies();
    }

    void AddAllEnemies()
    {
        List<Transform> enemies;

        bool isEnemy = core.faction.Faction == 1;

        if (isEnemy)
        {
            enemies = core.tracker.allies;
        }
        else
        {
            enemies = core.tracker.enemies;
        }

        foreach (Transform enemy in enemies)
        {
            targets.Add(enemy);
        }

        TargetEnemy();
    }

    void TargetEnemy()
    {
        if (selectedTarget != null)
        {
            SortTargetByDistance();
            int index = targets.IndexOf(selectedTarget);

            if (index < targets.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        else
        {
            SortTargetByDistance();
        }
    }

    void SortTargetByDistance()
    {
        targets.Sort(delegate (Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
        });

        SelectTarget();
    }

    void SelectTarget()
    {
        if (targets.Count == 0) { return; }
        else
        {
            selectedTarget = targets[0];
            core.logic.aiTarget = selectedTarget.transform;
        }
    }

    void DeselectTarget()
    {
        if (selectedTarget != null)
        {
            selectedTarget = null;
            targets.Clear();
        }
    }

    void AssignToTracker()
    {
        if (!core.tracker.ConstantUpdate)
        {
            if (core.faction.Faction == 0)
            {
                core.tracker.allies.Add(gameObject.transform);
            }
            else
            {
                core.tracker.enemies.Add(gameObject.transform);
            }
        }
    }

    public void RemoveFromTracker()
    {
        if (core.faction.Faction == 0)
        {
            core.tracker.allies.Remove(transform);
        }
        else
        {
            core.tracker.enemies.Remove(transform);
        }
    }
}
