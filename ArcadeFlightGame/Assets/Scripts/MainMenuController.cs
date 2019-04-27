using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Scene SceneToLoad;
    //[SerializeField] private Scene LeaderboardScene;
    private void Awake() {
        Debug.Log("Scene Opened: " + SceneManager.GetActiveScene().name);
    }

    public void PlayGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneToLoad.handle);
    }

    /*public void LeaderboardMenu() {
        SceneManager.LoadScene(LeaderboardScene.handle);
    }*/

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
