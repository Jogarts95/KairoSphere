using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 GetInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        return new Vector2(h, v);
    }
}

