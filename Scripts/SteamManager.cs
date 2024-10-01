using UnityEngine;
using System.Collections;
using Steamworks;
namespace develop_steam
{
    public class SteamManager : MonoBehaviour
    {
        private void Start()
        {
            if (SteamAPI.RestartAppIfNecessary((AppId_t)3267100)) // AppIDを自分のAppIDに置き換える
            {
                Application.Quit();
                return;
            }

            if (!SteamAPI.Init())
            {
                Debug.LogError("Steam API initialization failed.");
                return;
            }

            Debug.Log("Steam API initialized");
        }

        private void OnDestroy()
        {
            SteamAPI.Shutdown();
        }

        // テストにて動作したコードet
        //void Start()
        //{
        //    if (SteamAPI.Init())
        //    {
        //        string name = SteamFriends.GetPersonaName();
        //        Debug.Log(name);
        //    }
        //}

        //void Update()
        //{
        //    // F1キーを押すとフレンドリストを表示
        //    if (Input.GetKeyDown(KeyCode.F1))
        //    {
        //        SteamFriends.ActivateGameOverlay("Friends");
        //    }         // F2キーを押すと、ゲームオーバーレイが開く
        //    if (Input.GetKeyDown(KeyCode.F2))
        //    {
        //        // Steamの一般オーバーレイ画面を表示
        //        SteamFriends.ActivateGameOverlay("overlay");
        //    }
        //}

        //private void OnDestroy()
        //{
        //    SteamAPI.Shutdown();
        //}

    }
}

