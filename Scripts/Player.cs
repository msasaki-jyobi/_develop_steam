using Mirror;
using System.Collections;
using UnityEngine;

namespace develop_steam
{
    public class Player : NetworkBehaviour
    {
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            Debug.Log("Player instance created for local player");
        }

        void Update()
        {
            if (!isLocalPlayer) return;

            // プレイヤーの操作（例: 移動処理）
            float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, moveX, 0);
            transform.Translate(0, 0, moveZ);
        }
    }
}