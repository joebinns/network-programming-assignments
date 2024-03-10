using Unity.Netcode;
using UnityEngine;

public class FiringAction : NetworkBehaviour
{
	[SerializeField] PlayerController playerController;
	[SerializeField] GameObject clientSingleBulletPrefab;
	[SerializeField] GameObject serverSingleBulletPrefab;
	[SerializeField] Transform bulletSpawnPoint;
	[SerializeField] Ammo ammo;

	public override void OnNetworkSpawn()
	{
		playerController.onFireEvent += Fire;
	}

	private void Fire(bool isShooting)
	{
		if (!isShooting) return;
		if (ammo.currentAmmo.Value <= 0) return;

		ShootLocalBullet();
		ammo.LoseAmmo(1);
	}

	[ServerRpc]
	private void ShootBulletServerRpc()
	{
		GameObject bullet = Instantiate(serverSingleBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());

		ShootBulletClientRpc();
	}

	[ClientRpc]
	private void ShootBulletClientRpc()
	{
		if (IsOwner) return;

		GameObject bullet = Instantiate(clientSingleBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());

	}

	private void ShootLocalBullet()
	{
		GameObject bullet = Instantiate(clientSingleBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());

		ShootBulletServerRpc();
	}
}
