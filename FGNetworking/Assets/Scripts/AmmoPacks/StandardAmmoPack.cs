using Unity.Netcode;
using UnityEngine;

public class StandardAmmoPack : NetworkBehaviour
{
	[SerializeField] GameObject ammoPackPrefab;

	private const int AMMO = 5;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!IsServer) return;

		var ammo = other.GetComponent<Ammo>();
		if (!ammo) return;

		ammo.GainAmmo(AMMO);

		var spawnPosition = new Vector3(
			Random.Range(-4f, 4f),
			Random.Range(-2f, 2f),
			0f);

		var newAmmoPack = Instantiate(ammoPackPrefab, spawnPosition, Quaternion.identity);
		var newNetworkObject = newAmmoPack.GetComponent<NetworkObject>();
		newNetworkObject.Spawn();

		var networkObject = gameObject.GetComponent<NetworkObject>();
		networkObject.Despawn();
	}
}
