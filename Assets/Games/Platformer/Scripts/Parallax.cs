using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class Parallax : MonoBehaviour
    {
        private float startPositionX;
        private float startPositionY;
        [SerializeField] private Camera Cam;
        public float parallaxEffect;

        void Start()
        {
            startPositionX = transform.position.x;
            startPositionY = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            float tempX = (Cam.transform.position.x * (1 - parallaxEffect));

            float distX = (Cam.transform.position.x * parallaxEffect);

            float tempY = (Cam.transform.position.y * (1 - parallaxEffect));

            float distY = (Cam.transform.position.y * parallaxEffect);

            transform.position = new Vector3(startPositionX + distX, startPositionY + distY, transform.position.z);
        }
    }
}
