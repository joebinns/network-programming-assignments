using Unity.Netcode;
using UnityEngine;

public class StandardHealthPack : NetworkBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!IsServer) return;

		var health = other.GetComponent<Health>();
		if (!health) return;

		health.GainHealth(25);

		var networkObject = gameObject.GetComponent<NetworkObject>();
		networkObject.Despawn();
	}
}
