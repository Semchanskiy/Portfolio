using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _spawnPoint;

        void Awake()
        {
            Instantiate<GameObject>(_player,
                new Vector2(_spawnPoint.transform.position.x, _spawnPoint.transform.position.y), Quaternion.identity);

        }

        public void CreatePlayer()
        {
            Instantiate<GameObject>(_player,
                new Vector2(_spawnPoint.transform.position.x, _spawnPoint.transform.position.y), Quaternion.identity);
        }

    }
}
