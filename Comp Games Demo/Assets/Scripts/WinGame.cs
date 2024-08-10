using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinGame : MonoBehaviour
{
    public GameObject winMenu;

    //public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Blender.isWon)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // public void ResumeGame()
    // {
    //     winMenu.SetActive(false);
    //     Time.timeScale = 1f;
    //     PauseMenu.isPaused = false;
    //     Cursor.lockState = CursorLockMode.Locked;
    //     Cursor.visible = false;
    // }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.isPaused = false;
        SceneManager.LoadScene("Start Menu");
        Blender.isWon = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
