using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

