using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PhotonRetryManager : MonoBehaviour
{
    public GameObject retryButton;
    public TextMeshProUGUI scoreText;
    public PhotonDamage photonDamage;

    private bool raceEnded = false;

    void Start()
    {
        Time.timeScale = 1f;
        retryButton.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    public void ShowRetry(bool fell = false)
    {
        if (raceEnded) return;

        raceEnded = true;

        int points = 0;

        if (!fell)
        {
            points = Mathf.RoundToInt(photonDamage.CurrentHealth);
        }

        scoreText.text = "Percentage of detection: " + points;
        scoreText.gameObject.SetActive(true);

        retryButton.SetActive(true);
        Time.timeScale = 0f;

        Debug.Log("Percentage of detection: " + points);
    }
    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}