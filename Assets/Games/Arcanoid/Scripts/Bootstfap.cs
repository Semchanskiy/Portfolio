using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class Bootstfap : MonoBehaviour
    {
        [SerializeField] private PlatformManager _platformManager;
        [SerializeField] private BallManager _ballManager;
        [SerializeField] private Hero _hero;
        [SerializeField] private Enemy _enemy;

        private void Awake()
        {

            _platformManager.Initialize();
            _ballManager.Initialize();
        }
    }
}
