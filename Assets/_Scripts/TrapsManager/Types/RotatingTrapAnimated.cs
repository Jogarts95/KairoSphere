using UnityEngine;

public class RotatingTrapAnimated : TrapBase
{
    [SerializeField] private Animator anim;
    [SerializeField] private string triggerName = "Activate";

    protected override void Start()
    {
        base.Start();
        Activate();
    }

    public override void Activate()
    {
        if (anim != null)
        {
            anim.SetTrigger(triggerName);
        }
    }
}
