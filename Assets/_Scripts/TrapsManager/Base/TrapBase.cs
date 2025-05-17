using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class TrapBase : MonoBehaviour, ITrap
{
    protected GameObject player;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public abstract void Activate();
    public virtual void Deactivate(){}
}
