using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlatformer
{
    public class PlatformerScenes : MonoBehaviour
    {
        public void StartLvl1()
        {
            SceneManager.LoadScene("Platformer.Lvl1");
        }
    }
}

