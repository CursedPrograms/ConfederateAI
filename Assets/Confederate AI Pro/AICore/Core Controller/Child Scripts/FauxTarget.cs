using UnityEngine;

[DisallowMultipleComponent]
public class FauxTarget : MonoBehaviour
{
    GlobalTracker tracker;

    public int Faction;

    void Start()
    {
        tracker = GetComponentInParent<GlobalTracker>();
        AssignToTargettingSystem();
    }

    void AssignToTargettingSystem()
    {
        if (!tracker.ConstantUpdate)
        {
            if (Faction == 0)
            {
                tracker.allies.Add(gameObject.transform);
            }
            else
            {
                tracker.enemies.Add(gameObject.transform);
            }
        }
    }
}
