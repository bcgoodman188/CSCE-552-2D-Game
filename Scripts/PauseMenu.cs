using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool gamePaused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gamePaused == true) {
                Resume();
            }
            else {
                Pause();
            }

        }
    }
    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void QuitGame() {
        Application.Quit();
    }
}
