using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public abstract class Block : MonoBehaviour
    {
        //[SerializeField] private GameObject test;
        protected int _lives; // кол-во ударов для уничтожения блока
        protected int _score; // урон что прибавляет блок к общему значению урона
        protected Animator anim;
        protected BoxCollider2D box2d;
        protected BallManager _ballManager;
        protected Score _scoreManager;

        void Start()
        {
            _scoreManager = FindAnyObjectByType<Score>();
            _ballManager = FindAnyObjectByType<BallManager>();
            anim = GetComponent<Animator>();
            box2d = GetComponent<BoxCollider2D>();
            Specifications();
        }

        protected virtual void Specifications()
        {
            _lives = 1;
        }

        public virtual void Punch() // происходит удар
        {
            _lives--; // отнимается жизнь у блока
            if (_lives == 0)
            {
                if (anim != null) // если есть аниматор
                {
                    anim.SetBool("Destroy", true); // блок уничтожается
                    CalculationCenter.AddDamage(_score); // добавить урон к общему значению


                }
                else
                {
                    CalculationCenter.AddDamage(_score);
                    gameObject.SetActive(false);
                }
            }
        }

        public virtual void Destroys() // метод уничтожения блока
        {
            gameObject.SetActive(false);
        }

    }
}
