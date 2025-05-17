using UnityEngine;

public class FireTrap : TrapBase
{

    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private float damage = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Activate();
            Debug.Log("Player tocó fuego");
        }
    }

    public override void Activate()
    {
        if (fireEffect != null && !fireEffect.isPlaying)
        {
            fireEffect.Play();
        }
    }

    public override void Deactivate()
    {
        if (fireEffect != null && fireEffect.isPlaying)
        {
            fireEffect.Stop();
        }
    }
}
