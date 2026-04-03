using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public static ElevatorManager Instance;

    public Elevator[] elevators;

    private void Awake()
    {
        Instance = this;
    }

    public void RequestElevator(int floor)
    {
        Elevator bestElevator = null;
        float bestScore = float.MaxValue;

        foreach (var elevator in elevators)
        {
            // 🚫 Skip elevator already at floor and idle
            if (elevator.currentFloor == floor && elevator.IsIdle())
                continue;

            float score = CalculateScore(elevator, floor);

            if (score < bestScore)
            {
                bestScore = score;
                bestElevator = elevator;
            }
        }

        // If all elevators were skipped (rare case), fallback to nearest anyway
        if (bestElevator == null)
        {
            foreach (var elevator in elevators)
            {
                float score = Mathf.Abs(elevator.currentFloor - floor);

                if (score < bestScore)
                {
                    bestScore = score;
                    bestElevator = elevator;
                }
            }
        }

        if (bestElevator != null)
        {
            bestElevator.AddRequest(floor);
        }
    }
    float CalculateScore(Elevator elevator, int requestedFloor)
    {
        int distance = Mathf.Abs(elevator.currentFloor - requestedFloor);

        // Priority logic
        if (elevator.IsIdle())
            return distance;

        if (elevator.direction == Elevator.Direction.Up &&
            requestedFloor >= elevator.currentFloor)
            return distance + 1;

        if (elevator.direction == Elevator.Direction.Down &&
            requestedFloor <= elevator.currentFloor)
            return distance + 1;

        // Penalize wrong direction heavily
        return distance + 100;
    }
}

