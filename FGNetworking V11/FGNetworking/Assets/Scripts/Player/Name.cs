using Unity.Collections;
using Unity.Netcode;

public class Name : NetworkBehaviour
{
	public NetworkVariable<FixedString128Bytes> UserName = new NetworkVariable<FixedString128Bytes>();

	public override void OnNetworkSpawn()
	{
		if (!IsServer) return;

		var userData = SavedClientInformationManager.GetUserData(OwnerClientId);
		UserName.Value = userData.userName;
	}
}
