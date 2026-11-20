using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 6, -10);

    public float normalSmoothness = 8f;
    public float collisionSmoothness = 20f;

    private Vector3 previousTargetPosition;

    void Start()
    {
        if (target != null)
            previousTargetPosition = target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;
        float movement = Vector3.Distance(
            target.position,
            previousTargetPosition
        );

        float smoothness = movement > 0.15f
            ? collisionSmoothness
            : normalSmoothness;

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothness * Time.deltaTime
        );

        previousTargetPosition = target.position;
    }
}