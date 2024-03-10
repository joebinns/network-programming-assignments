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

		var newPosition = new Vector3(
			Random.Range(-4f, 4f),
			Random.Range(-2f, 2f),
			0f);

		transform.position = newPosition;
		SetPositionClientRpc(newPosition);
	}

	[ClientRpc]
	private void SetPositionClientRpc(Vector3 newPosition)
	{
		transform.position = newPosition;
	}
}
