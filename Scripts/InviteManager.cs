using Mirror;
using Steamworks;
using System.Collections;
using UnityEngine;

namespace develop_steam
{
    public class InviteManager : MonoBehaviour
    {
        public void InviteFriend()
        {
            // オーバーレイでフレンドを招待する
            CSteamID lobbyID = SteamUser.GetSteamID(); // 現在のプレイヤーをロビーIDとして仮設定
            SteamFriends.ActivateGameOverlayInviteDialog(lobbyID);
        }

        public void JoinGame()
        {
            // Mirrorを使ってクライアントを接続
            NetworkManager.singleton.StartClient();
            Debug.Log("Joining game as a client...");
        }
    }
}