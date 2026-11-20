using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("Game Resumed");
        }
    }
}