using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonClick : MonoBehaviour
{
    public BallPrefab ballPrefab;
    public Scoreboard scoreboard;

    void Update()
    {
        if (Touchscreen.current.press.wasPressedThisFrame)
        {
            // if all shots have been used, restart instead
            if (scoreboard.GetShots() >= 10)
            {
                scoreboard.RestartGame();
                return;
            }

            BallPrefab ball = Instantiate<BallPrefab>(ballPrefab);

            ball.transform.position = transform.position;

            ball.GetComponent<Rigidbody>().AddForce(
                Camera.main.transform.forward *
                UnityEngine.Random.Range(1000, 1500)
            );

            scoreboard.AddShot();
        }
    }
}