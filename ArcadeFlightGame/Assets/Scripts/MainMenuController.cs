using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [HideInInspector] public int playerScore = 0;
    public int playerHealth = 5;

    [SerializeField] private Scene SceneToLoad;
    [SerializeField] private Scene LeaderboardScene;
    private void Awake() {
        //Time.timeScale = 0f;
        Debug.Log("Scene Opened: " + SceneManager.GetActiveScene().name);
    }

    public void PlayGame() {
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);
        PlayerPrefs.SetString("PlayerTimeString", "");
        SceneManager.LoadScene(SceneToLoad.handle);
    }

    public void LeaderboardMenu() {
        SceneManager.LoadScene(LeaderboardScene.handle);
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
