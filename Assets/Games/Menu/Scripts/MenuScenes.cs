using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenes : MonoBehaviour
{
    public void StartMemoryCard()
    {
        SceneManager.LoadScene("MemoryCard.Lvl1");
    }

    public void StartArcanoid()
    {
        SceneManager.LoadScene("Arcanoid.Menu");
    }

    public void StartPlatformer()
    {
        SceneManager.LoadScene("Platformer.Menu");
    }

    public void StartBalless()
    {
        SceneManager.LoadScene("Balless.Lvl1");
    }

}
