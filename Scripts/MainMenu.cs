using develop_steam;
using Mirror;
using System.Collections;
using UnityEngine;

namespace develop_steam
{
    public class MainMenu : MonoBehaviour
    {
        public InviteManager inviteManager;

        public void OnStartHost()
        {
            NetworkManager.singleton.StartHost();
            Debug.Log("Host started");
        }

        public void OnInviteFriend()
        {
            inviteManager.InviteFriend();
        }

        public void OnJoinGame()
        {
            inviteManager.JoinGame();
        }
    }
}