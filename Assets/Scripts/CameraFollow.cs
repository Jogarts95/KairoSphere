using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0f, 8f, -6f);
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;
        
        Vector3 desirePosition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);

        transform.position = smoothed;
        transform.LookAt(target);
    }
}
