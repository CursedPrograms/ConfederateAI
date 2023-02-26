using UnityEngine;

[DisallowMultipleComponent]
public class AISave : MonoBehaviour
{
    public Vector3 startPos;
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
