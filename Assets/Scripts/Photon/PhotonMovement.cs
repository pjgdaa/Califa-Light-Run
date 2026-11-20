using UnityEngine;

public class PhotonMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;

    private int currentLane = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();

        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();

        transform.Translate(
            Vector3.forward * forwardSpeed * Time.deltaTime
        );

        float targetX = (currentLane - 1) * laneDistance;

        Vector3 targetPosition = new Vector3(
            targetX,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            laneChangeSpeed * Time.deltaTime
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
        int newLane = Random.Range(0, 2);

        if (newLane >= currentLane)
            newLane++;

        currentLane = newLane;
    }
}