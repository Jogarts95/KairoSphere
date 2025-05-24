using UnityEngine;

public class RandomFlicker : MonoBehaviour
{
    public float moveRange = 0.1f;
    public float speed = 2f;

    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        Vector3 offset = new Vector3(
            Mathf.PerlinNoise(Time.time * speed, 0) - 0.5f,
            0,
            Mathf.PerlinNoise(0, Time.time * speed) - 0.5f
        ) * moveRange;

        transform.localPosition = originalPosition + offset;
    }
}
