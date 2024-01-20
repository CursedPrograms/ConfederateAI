using UnityEngine;

[DisallowMultipleComponent]
public class AISave : MonoBehaviour
{
    [HideInInspector]
    public Vector3 startPos;
    [HideInInspector]
    public Quaternion startRot;

    void Start()
    {
        SavePos();
    }

    void SavePos()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }
}
