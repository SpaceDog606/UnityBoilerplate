using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelecter : MonoBehaviour
{
    public void level1()
    {
        //tells unit to load the main game scenes.
        SceneManager.LoadScene(3);
    }
    public void level2()
    {
        //tells unit to load the main game scenes.
        SceneManager.LoadScene(4);
    }
    public void level3()
    {
        //tells unit to load the main game scenes.
        SceneManager.LoadScene(1);
    }
    public void level4()
    {
        //tells unit to load the main game scenes.
        SceneManager.LoadScene(1);
    }
    public void level5()
    {
        //tells unit to load the main game scenes.
        SceneManager.LoadScene(1);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }
}