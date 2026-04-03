using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Elevator Settings")]
    public int currentFloor = 0;
    public float speed = 2f;
    public Transform[] floorPoints;

    private Queue<int> requestQueue = new Queue<int>();
    private bool isMoving = false;

    private float lockedX; // prevents horizontal drift

    public enum Direction { Up, Down, Idle }
    public Direction direction = Direction.Idle;

    private void Start()
    {
        // Lock initial X position
        lockedX = transform.position.x;
    }

    private void Update()
    {
        if (!isMoving && requestQueue.Count > 0)
        {
            int nextFloor = requestQueue.Dequeue();
            StartCoroutine(MoveToFloor(nextFloor));
        }
    }

    public void AddRequest(int floor)
    {
        if (!requestQueue.Contains(floor))
        {
            requestQueue.Enqueue(floor);
        }
    }

    private IEnumerator MoveToFloor(int targetFloor)
    {
        isMoving = true;

        float targetY = floorPoints[targetFloor].position.y;

        direction = targetFloor > currentFloor ? Direction.Up : Direction.Down;

        while (Mathf.Abs(transform.position.y - targetY) > 0.01f)
        {
            float newY = Mathf.MoveTowards(
                transform.position.y,
                targetY,
                speed * Time.deltaTime
            );

            transform.position = new Vector3(
                lockedX,           // X stays fixed
                newY,              // Only Y moves
                transform.position.z
            );

            yield return null;
        }

        // Snap exactly to final position (prevents float precision issues)
        transform.position = new Vector3(
            lockedX,
            targetY,
            transform.position.z
        );

        currentFloor = targetFloor;
        direction = Direction.Idle;
        isMoving = false;
    }

    public bool IsIdle()
    {
        return !isMoving && requestQueue.Count == 0;
    }
}