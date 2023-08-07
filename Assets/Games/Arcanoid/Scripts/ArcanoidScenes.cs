using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcanoidScenes : MonoBehaviour
{
    public void StartLvl1()
    {
        SceneManager.LoadScene("Arcanoid.Lvl1");
    }
}
