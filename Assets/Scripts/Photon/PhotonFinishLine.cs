using UnityEngine;

public class PhotonFinishLine : MonoBehaviour
{
    public PhotonRetryManager retryManager;
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