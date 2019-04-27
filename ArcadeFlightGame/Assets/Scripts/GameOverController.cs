using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private InputField input;
    [SerializeField] private Scene sceneToLoad;

    private void Awake() {
        //input = GameObject.Find("InputField").GetComponent<InputField>();
        input.characterLimit = 3;
        input.ActivateInputField();
    }

    public void GetInput(string name) {
        name = input.text;
        name = name.ToUpper();
        Debug.Log("You Entered: " + name);
    }

    public void LoadScene() {
        Time.timeScale = 1f;
        Debug.Log("Opening Scene: " + sceneToLoad.name);
        SceneManager.LoadScene(sceneToLoad.handle);
    }
}
