using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ProtonRetryManager : MonoBehaviour
{
    public GameObject retryButton;
    public TextMeshProUGUI scoreText;
    public ProtonDamage playerDamage;
    
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
            points = Mathf.RoundToInt(playerDamage.CurrentHealth);
        }

        scoreText.text = "Percentege of detection: " + points;
        scoreText.gameObject.SetActive(true);

        retryButton.SetActive(true);
        Time.timeScale = 0f;

        Debug.Log("Percentege of detection: " + points);
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}