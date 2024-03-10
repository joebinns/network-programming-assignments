using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
	public NetworkVariable<int> currentHealth = new NetworkVariable<int>();

	private const int MIN_HEALTH = 0;
	private const int MAX_HEALTH = 100;


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

	public void TakeDamage(int damage)
	{
		currentHealth.Value -= Mathf.Abs(damage);
		currentHealth.Value = Mathf.Max(currentHealth.Value, MIN_HEALTH);
	}

}
