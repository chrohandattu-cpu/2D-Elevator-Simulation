using UnityEngine;
using TMPro;

public class ElevatorUI : MonoBehaviour
{
    public Elevator elevator;
    public TextMeshProUGUI floorText;

    void Update()
    {
        floorText.text = "F:" + elevator.currentFloor;
    }
}