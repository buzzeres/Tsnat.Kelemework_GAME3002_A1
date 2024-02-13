using UnityEngine;

public class FixedRotationCamera : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = initialRotation;
    }
}