using UnityEngine;
using Mirror;

namespace develop_steam
{
    public class MirrorGameManager : NetworkManager
    {
        public override void OnStartHost()
        {
            base.OnStartHost();
            Debug.Log("Host started, waiting for players...");
        }

        //public override void OnServerAddPlayer(NetworkConnection conn)
        //{
        //    GameObject player = Instantiate(playerPrefab);
        //    NetworkServer.AddPlayerForConnection(conn, player);
        //    Debug.Log("Player added to game");
        //}

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            base.OnServerAddPlayer(conn); 
            GameObject player = Instantiate(playerPrefab);
            NetworkServer.AddPlayerForConnection(conn, player);
            Debug.Log("Player added to game");
        }
    }

}
