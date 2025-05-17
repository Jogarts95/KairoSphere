using UnityEngine;

public static class TrapFactory
{
    public static ITrap CreateTrap(TrapType type, GameObject obj)
    {
        return type switch
        {
            TrapType.Fire => obj.GetComponent<FireTrap>(),
            //
            _ => null
        };
    }
}
