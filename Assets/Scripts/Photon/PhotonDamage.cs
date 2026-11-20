using UnityEngine;
using UnityEngine.UI;

public class PhotonDamage : MonoBehaviour
{
    public Slider healthBar;
    public float damage = 10f;
    public PhotonRetryManager retryManager;
    public PhotonMovement photonMovement;

    public Material[] energyMaterials;
    private Renderer playerRenderer;

    private float health = 100f;
    private bool isDead = false;

    private float hitCooldown = 0.2f;
    private float nextHitTime = 0f;

    public float CurrentHealth => health;

    void Start()
    {
        health = 100f;
        healthBar.value = health;

        playerRenderer = GetComponentInChildren<Renderer>();
        UpdatePlayerMaterial();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDead) return;
        if (!other.CompareTag("Obstacle")) return;
        if (Time.time < nextHitTime) return;

        nextHitTime = Time.time + hitCooldown;

        ObstacleFlash flash = other.GetComponentInParent<ObstacleFlash>();

        if (flash != null)
        {
            flash.Flash();
        }

        health -= damage;
        health = Mathf.Clamp(health, 0, 100);

        UpdatePlayerMaterial();
        healthBar.value = health;

        photonMovement.HitObstacle();

        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;
        Debug.Log("PLAYER DIED!");

        retryManager.ShowRetry();

        gameObject.SetActive(false);
    }

    void UpdatePlayerMaterial()
    {
        if (playerRenderer == null || energyMaterials == null || energyMaterials.Length < 11)
            return;

        int materialIndex = Mathf.RoundToInt(health / 10f);
        materialIndex = Mathf.Clamp(materialIndex, 0, 10);

        playerRenderer.material = energyMaterials[materialIndex];
    }
}