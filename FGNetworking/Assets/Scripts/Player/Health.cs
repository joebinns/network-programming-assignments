using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
	public NetworkVariable<int> currentHealth = new NetworkVariable<int>();

	[SerializeField] private PlayerController playerController;

	public const int MAX_HEALTH = 100;

	public override void OnNetworkSpawn()
	{
		if (!IsServer) return;

		currentHealth.Value = MAX_HEALTH;
		playerController.onRespawnEvent += ResetHealth;
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

		if (currentHealth.Value <= 0)
		{
			playerController.Kill();
		}
	}

	public void ResetHealth() => currentHealth.Value = MAX_HEALTH;
}
