using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{   
    public void OpenInformation()
    {
        SceneManager.LoadScene("Information");
    }
    public void PlayGame()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene("CharacterSelection");
}
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
