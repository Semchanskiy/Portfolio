using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class MovingCamera : MonoBehaviour
    {
        private PlayerController _playerController;

        void Start()
        {
            FindPlayer();
        }

        public void FindPlayer()
        {
            _playerController = FindObjectOfType<PlayerController>();
            transform.position = new Vector3(_playerController.transform.position.x,_playerController.transform.position.y, -10);

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(_playerController.transform.position.x, _playerController.transform.position.y, -10);
        }
    }
}
