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

    public void LoadLvl1()
    {
        SceneManager.LoadScene("Arcanoid.Lvl1");
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene("Arcanoid.Lvl2");
    }
    public void LoadLvl3()
    {
        SceneManager.LoadScene("Arcanoid.Lvl3");
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
