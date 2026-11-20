using UnityEngine;

public class PhotonLight : MonoBehaviour
{
    public Light playerLight;
    public PhotonDamage photonDamage;

    [Header("Light Settings")]
    public float maximumIntensity = 5f;
    public float minimumIntensity = 0.2f;

    public float maximumRange = 8f;
    public float minimumRange = 1f;

    public float transitionSpeed = 3f;

    void Update()
    {
        float energy = photonDamage.CurrentHealth;

        float energyPercentage = Mathf.Clamp01(energy / 100f);

        float targetIntensity = Mathf.Lerp(
            minimumIntensity,
            maximumIntensity,
            energyPercentage
        );

        float targetRange = Mathf.Lerp(
            minimumRange,
            maximumRange,
            energyPercentage
        );

        playerLight.intensity = Mathf.Lerp(
            playerLight.intensity,
            targetIntensity,
            transitionSpeed * Time.deltaTime
        );

        playerLight.range = Mathf.Lerp(
            playerLight.range,
            targetRange,
            transitionSpeed * Time.deltaTime
        );
    }
}