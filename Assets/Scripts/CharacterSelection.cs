using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public void SelectProton()
    {
        SceneManager.LoadScene("Proton");
    }

    public void SelectPhoton()
    {
        SceneManager.LoadScene("Photon");
    }
}