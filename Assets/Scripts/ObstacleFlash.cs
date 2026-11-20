using UnityEngine;
using System.Collections;

public class ObstacleFlash : MonoBehaviour
{
    public Material flashMaterial;
    public float flashDuration = 0.2f;

    private Renderer obstacleRenderer;
    private Material[] originalMaterials;
    private Coroutine flashCoroutine;

    void Start()
    {
        obstacleRenderer = GetComponentInChildren<Renderer>();

        if (obstacleRenderer != null)
        {
            originalMaterials = obstacleRenderer.materials;
        }
    }

    public void Flash()
    {
        if (obstacleRenderer == null || flashMaterial == null)
            return;

        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FlashEffect());
    }

    IEnumerator FlashEffect()
    {
        Material[] flashMaterials = new Material[originalMaterials.Length];

        for (int i = 0; i < flashMaterials.Length; i++)
        {
            flashMaterials[i] = flashMaterial;
        }

        obstacleRenderer.materials = flashMaterials;

        yield return new WaitForSeconds(flashDuration);

        obstacleRenderer.materials = originalMaterials;

        flashCoroutine = null;
    }
}