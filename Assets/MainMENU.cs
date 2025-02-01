using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMENU : MonoBehaviour
{
    public GameObject menuUI;  // Assign the pause menu UI in the Inspector
    private bool isPaused = false;  // Track whether the game is paused

    void Update()
    {
        // Toggle the pause menu when the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void Start()
    {
        PauseGame();
    }

    public void PlayGame()
    {
        ResumeGame();  // Resume the game if the Play button is clicked
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    void PauseGame()
    {
        menuUI.SetActive(true);  // Show the menu
        Time.timeScale = 0f;     // Pause the game (stop time)
        isPaused = true;
    }

    public void ResumeGame()
    {
        menuUI.SetActive(false); // Hide the menu
        Time.timeScale = 1f;     // Resume the game (normal time)
        isPaused = false;
    }
}
