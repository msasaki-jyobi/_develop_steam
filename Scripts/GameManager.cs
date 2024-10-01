using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace develop_steam
{
    public class GameManager : MonoBehaviour
    {
        public Text winText;
        private bool gameEnded = false;

        void Start()
        {
            SteamNetworking.AcceptP2PSessionWithUser(SteamUser.GetSteamID()); // セッションの受け入れ
        }

        void Update()
        {
            // P2Pからのメッセージ受信
            uint msgSize;
            if (SteamNetworking.IsP2PPacketAvailable(out msgSize))
            {
                byte[] buffer = new byte[msgSize];
                CSteamID remoteID;
                if (SteamNetworking.ReadP2PPacket(buffer, msgSize, out uint bytesRead, out remoteID))
                {
                    HandleP2PMessage(buffer, remoteID);
                }
            }
        }

        void HandleP2PMessage(byte[] data, CSteamID senderID)
        {
            // メッセージを受け取ったら、相手にダメージを与える処理
            if (data.Length > 0 && data[0] == 1) // ダミーデータを確認
            {
                PlayerManager[] players = FindObjectsOfType<PlayerManager>();
                foreach (var player in players)
                {
                    if (player.GetSteamID() == senderID)
                    {
                        player.TakeDamage(20f); // 仮のダメージ
                    }
                }
            }
        }

        public void HandlePlayerDeath(PlayerManager deadPlayer)
        {
            if (gameEnded) return;

            gameEnded = true;
            PlayerManager[] players = FindObjectsOfType<PlayerManager>();
            foreach (PlayerManager player in players)
            {
                if (player != deadPlayer)
                {
                    DisplayWinner(player.playerName);
                }
            }

            // 勝者名をP2Pで送信
            byte[] winMessage = System.Text.Encoding.UTF8.GetBytes("WIN:" + deadPlayer.playerName);
            SteamNetworking.SendP2PPacket(SteamUser.GetSteamID(), winMessage, (uint)winMessage.Length, EP2PSend.k_EP2PSendReliable);
        }

        void DisplayWinner(string winnerName)
        {
            winText.text = winnerName + ": WIN!";
            winText.gameObject.SetActive(true);
        }
    }
}

