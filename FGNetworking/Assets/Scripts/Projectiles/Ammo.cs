using Unity.Netcode;
using UnityEngine;

public class Ammo : NetworkBehaviour
{
	public NetworkVariable<int> currentAmmo = new NetworkVariable<int>();

	public const int MAX_AMMO = 10;

	public override void OnNetworkSpawn()
	{
		if (!IsServer) return;

		currentAmmo.Value = MAX_AMMO;
	}

	public void GainAmmo(int ammo)
	{
		currentAmmo.Value += Mathf.Abs(ammo);
		currentAmmo.Value = Mathf.Min(currentAmmo.Value, MAX_AMMO);
	}

	public void LoseAmmo(int ammo)
	{
		currentAmmo.Value -= Mathf.Abs(ammo);
		currentAmmo.Value = Mathf.Max(currentAmmo.Value, 0);
	}

}
