using Unity.Collections;
using Unity.Netcode;

public class Name : NetworkBehaviour
{
    public NetworkVariable<FixedString128Bytes> UserName = new NetworkVariable<FixedString128Bytes>();

    public override void OnNetworkSpawn()
    {
        //if (!IsServer) return;

        var networkId = NetworkObjectId;
		var userData = SavedClientInformationManager.GetUserData(networkId);

        if (userData == null) return;

        UserName.Value = userData.userName; // TODO: Change this to the name as stored in the user data in saved client information manager
    }
}
