using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public void StartMemoryCard()
    {
        SceneManager.LoadScene("Game.MemoryCard");
    }

    public void StartArcanoid()
    {
        SceneManager.LoadScene("Arcanoid.Menu");
    }

    public void LoadArcanoidLvl1()
    {
        SceneManager.LoadScene("Arcanoid.Lvl1");
    }
    public void LoadArcanoidLvl2()
    {
        SceneManager.LoadScene("Arcanoid.Lvl2");
    }
    public void LoadArcanoidLvl3()
    {
        SceneManager.LoadScene("Arcanoid.Lvl3");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadPlatformerMenu()
    {
        SceneManager.LoadScene("Platformer.Menu");
    }
    public void LoadPlatformerLevels()
    {
        SceneManager.LoadScene("Platformer.Menu");
    }

    public void LoadPlatformerLvl1()
    {
        SceneManager.LoadScene("Platformer.Lvl1");
    }
    public void LoadPlatformerLvl2()
    {
        SceneManager.LoadScene("Platformer.Lvl2");
    }
    public void LoadPlatformerLvl3()
    {
        SceneManager.LoadScene("Platformer.Lvl3");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
