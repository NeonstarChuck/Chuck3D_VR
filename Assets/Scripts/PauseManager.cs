using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public InputActionReference pauseAction;
    private bool isPaused = false;
    public GameObject pausePanel;
    public AudioSource audioSource;


    void Update()
    {
        // Press Escape to toggle pause
        if (pauseAction.action.WasPerformedThisFrame())
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;   // Pause game

            Debug.Log("Game Paused");
            pausePanel.SetActive(true);
            if (audioSource != null)
                audioSource.Pause();

        }
        else
        {
            Time.timeScale = 1f;   // Resume game
            Debug.Log("Game Resumed");
            pausePanel.SetActive(false);
            if (audioSource != null)
                audioSource.UnPause();
        }
    }
}
