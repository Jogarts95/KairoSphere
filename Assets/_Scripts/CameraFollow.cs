using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // A qué objeto seguir (la pelota)
    public Vector3 offset = new Vector3(0f, 8f, -6f); // Posición relativa a la pelota
    public float smoothSpeed = 0.125f; // Suavidad del movimiento

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothed;
        transform.LookAt(target);
    }
}
