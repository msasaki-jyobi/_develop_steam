using UnityEngine;
using System.Collections;
using Steamworks;
namespace develop_steam
{
    public class SteamManager : MonoBehaviour
    {
        private void Start()
        {
            if (SteamAPI.RestartAppIfNecessary((AppId_t)3267100)) // AppID��������AppID�ɒu��������
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

        // �e�X�g�ɂē��삵���R�[�het
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
        //    // F1�L�[�������ƃt�����h���X�g��\��
        //    if (Input.GetKeyDown(KeyCode.F1))
        //    {
        //        SteamFriends.ActivateGameOverlay("Friends");
        //    }         // F2�L�[�������ƁA�Q�[���I�[�o�[���C���J��
        //    if (Input.GetKeyDown(KeyCode.F2))
        //    {
        //        // Steam�̈�ʃI�[�o�[���C��ʂ�\��
        //        SteamFriends.ActivateGameOverlay("overlay");
        //    }
        //}

        //private void OnDestroy()
        //{
        //    SteamAPI.Shutdown();
        //}

    }
}

