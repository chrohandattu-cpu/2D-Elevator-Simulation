using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public int floorNumber;

    public void OnPress()
    {
        ElevatorManager.Instance.RequestElevator(floorNumber);
    }
}