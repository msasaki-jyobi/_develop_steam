using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Steamworks;

namespace develop_steam
{
    public class PlayerManager : MonoBehaviour
    {
        public string playerName;
        public float health = 100f;
        public GameObject projectilePrefab;
        public Transform firePoint;
        public float projectileSpeed = 10f;

        private CSteamID steamID; // プレイヤーのSteamIDを保持するフィールド

        void Start()
        {
            playerName = SteamFriends.GetPersonaName(); // Steamのプレイヤー名を取得
            steamID = SteamUser.GetSteamID(); // プレイヤーのSteamIDを取得して保持
        }

        void Update()
        {
            // 簡単な移動
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.Translate(movement * Time.deltaTime * 5f);

            // 発射
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

        void Shoot()
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * projectileSpeed;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                FindObjectOfType<GameManager>().HandlePlayerDeath(this);
            }
        }

        // SteamIDを返すメソッドを追加
        public CSteamID GetSteamID()
        {
            return steamID;
        }
    }

}
