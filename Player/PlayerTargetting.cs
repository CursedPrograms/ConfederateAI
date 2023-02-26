using UnityEngine;

[DisallowMultipleComponent]
public class PlayerTargetting : MonoBehaviour
{
    GlobalTracker tracker;

    void Start()
    {
        tracker = GameObject.FindGameObjectWithTag("GameController").GetComponent<GlobalTracker>();
        AssignToTargettingSystem();
    }

    void AssignToTargettingSystem()
    {
        if (!tracker.ConstantUpdate)
        {
            tracker.allies.Add(gameObject.transform);
        }
    }
}
