using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    // Reloads current scene if game is lost
    public void LoadCurrentScene() {
        // resets score
        FindObjectOfType<GameSession>().ResetScore();

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); 
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0);

        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame() {
        Application.Quit();
    }
}
