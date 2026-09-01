using UnityEngine;

public class Target : MonoBehaviour
{
    public Scoreboard scoreboard;
    public TargetMovement targetMovement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallPrefab>() != null)
        {
            Vector3 hitPoint = collision.contacts[0].point;

            Vector2 hitPosition = new Vector2(hitPoint.x, hitPoint.z);
            Vector2 centerPosition = new Vector2(
                transform.position.x,
                transform.position.z
            );

            float distance = Vector2.Distance(hitPosition, centerPosition);

            Debug.Log("Distance from center: " + distance);

            scoreboard.ShowScore(distance);
            targetMovement.MoveTarget();
        }
    }
}