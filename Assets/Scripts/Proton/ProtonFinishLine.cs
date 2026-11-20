using UnityEngine;

public class ProtonFinishLine : MonoBehaviour
{
    public ProtonRetryManager retryManager;
    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.CompareTag("Player"))
        {
            finished = true;
            retryManager.ShowRetry();
        }
    }
}