using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(BallVisualController))]
public class NetworkBall : NetworkBehaviour
{
    private BallVisualController visual;
    private PlayerInputHandler input;

    private void Awake()
    {
        visual = GetComponent<BallVisualController>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        if (!IsOwner || visual.IsDead) return;

        Vector2 moveInput = input.GetInput();
        visual.Move(moveInput);
    }

    [ServerRpc]
    public void KillPlayerServerRpc()
    {
        // Solo el servidor decide la muerte
        KillPlayerClientRpc();
    }

    [ClientRpc]
    private void KillPlayerClientRpc()
    {
        visual.Kill();
    }
}
