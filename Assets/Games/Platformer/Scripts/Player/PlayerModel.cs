using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class PlayerModel : MonoBehaviour
    {
        public float speed;
        public float jumpForse;
        public int lives;
        public float acceleration;
        public float decceleration;
        public float velPower;
        public float frictionAmount;
        public bool _isVulnerability; //у€звимость

        void Start()
        {
            _isVulnerability = true;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
