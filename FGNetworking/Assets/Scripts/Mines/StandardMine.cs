using Unity.Netcode;
using UnityEngine;

public class StandardMine : NetworkBehaviour
{
	[SerializeField] GameObject minePrefab;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (IsServer)
		{
			Health health = other.GetComponent<Health>();
			if (!health) return;
			health.LoseHealth(25);

			var newPosition = new Vector3(
				Random.Range(-4f, 4f),
				Random.Range(-2f, 2f),
				0f);

			transform.position = newPosition;
			SetPositionClientRpc(newPosition);
		}
	}

	[ClientRpc]
	private void SetPositionClientRpc(Vector3 newPosition)
	{
		transform.position = newPosition;
	}
}
