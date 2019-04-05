using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour {

    //Loads the next map that is on the build list
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quits the game, Does not work during editor
    public void QuitGame()
    {
        Application.Quit();
    }
}
