using Unity.Netcode;

public class Name : NetworkBehaviour
{
    public NetworkVariable<string> CurrentName = new NetworkVariable<string>();

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;

        CurrentName.Value = "networked name"; // TODO: Change this to the name as stored in the user data in saved client information manager
    }
}
