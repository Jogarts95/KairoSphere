using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador tocó la trampa");
            // Aquí puedes reiniciar, quitar vida, etc.
        }
    }
}
