using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMemoryCards
{
    public class MemoryCard : MonoBehaviour
    {
        [SerializeField] private GameObject cardBack;
        [SerializeField] private SceneController controller;

        private int _id;

        public int id
        {
            get { return _id; }
        }

        public void SetCard(int id, Sprite image)
        {
            _id = id;
            GetComponent<SpriteRenderer>().sprite = image;
        }
        //[SerializeField] private Sprite image;

        public void OnMouseDown()
        {
            if (cardBack.activeSelf && controller.canReveal)
            {
                cardBack.SetActive(false);
                controller.CardRevealed(this);
            }
        }

        public void Unreveal()
        {
            cardBack.SetActive(true);
        }

        void Start()
        {
            //GetComponent<SpriteRenderer>().sprite = image;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
