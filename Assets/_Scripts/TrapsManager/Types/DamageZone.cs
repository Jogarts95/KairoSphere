using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó la trampa");
            Ball ball = other.GetComponent<Ball>();
            if (ball != null)
            {
                ball.KillPlayer();
            }
        }
    }
}
