using UnityEngine;

public class SpikeTrap : TrapBase
{
    [SerializeField] private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Activate();
        }
    }

    public override void Activate()
    {
        anim.SetTrigger("Activate");
    }
}
