using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Function to be called when the 'Start Game' button is pressed
    public void StartGame()
    {
        // Replace "YourGameSceneName" with the name of the scene you want to load
        SceneManager.LoadScene("LevelOne");
    }

    // Function to be called when the 'Quit' button is pressed
    public void QuitGame()
    {
        // Quit the application
        // Note: This will only work in a built game, not in the Unity editor
        Application.Quit();

        // This line is for debugging purposes and can be removed for the final build
        Debug.Log("Quit Game pressed");
    }
}
