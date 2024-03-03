using Unity.Collections;
using Unity.Netcode;

public class Name : NetworkBehaviour
{
    public NetworkVariable<FixedString128Bytes> CurrentName = new NetworkVariable<FixedString128Bytes>();

    public override void OnNetworkSpawn()
    {
        //if (!IsServer) return;

        CurrentName.Value = "networked_name"; // TODO: Change this to the name as stored in the user data in saved client information manager
    }
}
