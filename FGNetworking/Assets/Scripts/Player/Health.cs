using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
	public NetworkVariable<int> currentHealth = new NetworkVariable<int>();

	public const int MAX_HEALTH = 100;

	public override void OnNetworkSpawn()
	{
		if (!IsServer) return;

		currentHealth.Value = MAX_HEALTH;
	}

	public void GainHealth(int health)
	{
		currentHealth.Value += Mathf.Abs(health);
		currentHealth.Value = Mathf.Min(currentHealth.Value, MAX_HEALTH);
	}

	public void LoseHealth(int health)
	{
		currentHealth.Value -= Mathf.Abs(health);
		currentHealth.Value = Mathf.Max(currentHealth.Value, 0);
	}

}
