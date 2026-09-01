using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    // changes the angle to get a good score but doesn't make you turn your entire body just to find target 
    public float horizontalRange = 8f;
    public float verticalRange = 6f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void MoveTarget()
    {
        float newX = initialPosition.x + Random.Range(-horizontalRange, horizontalRange);
        float newY = initialPosition.y + Random.Range(-verticalRange, verticalRange);

        transform.position = new Vector3(
            newX,
            newY,
            initialPosition.z
        );
    }

    public void ResetTarget()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}