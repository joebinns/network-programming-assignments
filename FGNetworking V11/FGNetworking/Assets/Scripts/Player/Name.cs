using Unity.Collections;
using Unity.Netcode;

public class Name : NetworkBehaviour
{
	public NetworkVariable<FixedString128Bytes> UserName = new NetworkVariable<FixedString128Bytes>();

	public override void OnNetworkSpawn()
	{
		if (!IsServer) return;

		var allClients = SavedClientInformationManager.GetAllClient();
		var userData = allClients[allClients.Count - 1].userData;
		UserName.Value = userData.userName;
	}
}
