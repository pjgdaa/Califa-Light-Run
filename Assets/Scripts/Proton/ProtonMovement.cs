using UnityEngine;

public class ProtonMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;

    [Header("Lane Movement")]
    public float laneSmoothTime = 0.15f;
    
    [Header("Collision Effects")]
    public float reducedSpeed = 4f;
    public float speedRecovery = 2.5f;
    private int currentLane = 1;
    private float currentSpeed;
    private float laneVelocity = 0f;
    void Start()
    {
        currentSpeed = forwardSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();

        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();

        currentSpeed = Mathf.MoveTowards(
            currentSpeed,
            forwardSpeed,
            speedRecovery * Time.deltaTime
        );

        transform.Translate(
            Vector3.forward * currentSpeed * Time.deltaTime
        );

        float targetX = (currentLane - 1) * laneDistance;

        float newX = Mathf.SmoothDamp(
            transform.position.x,
            targetX,
            ref laneVelocity,
            laneSmoothTime
        );

        transform.position = new Vector3(
            newX,
            transform.position.y,
            transform.position.z
        );
    }

    public void MoveLeft()
    {
        currentLane = Mathf.Max(0, currentLane - 1);
    }

    public void MoveRight()
    {
        currentLane = Mathf.Min(2, currentLane + 1);
    }

    public void HitObstacle()
    {
        currentSpeed = reducedSpeed;
    }
}