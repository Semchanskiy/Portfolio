using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class PlayerView : MonoBehaviour
    {
        [HideInInspector] public bool _isFacingRight = true;

        [HideInInspector] public float _nextStep = 0.0f;
        public float _stepRate;


        [HideInInspector] public Animator _anim;

        public AudioSource _soundJump;
        public AudioSource _soundStep;

        void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
