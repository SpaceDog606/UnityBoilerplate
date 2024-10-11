using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
       public void PlayGame()
    {
        //tells unit to load the main game scenes.
        SceneManager.LoadScene("Level Select");
    }

    public void Quit()
    {
        //closes the game
        Application.Quit();
    }
}
