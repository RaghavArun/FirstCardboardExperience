using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public TargetMovement targetMovement;

    private int totalScore = 0;
    private int shots = 0;

    private const int maxShots = 10;

    void Start()
    {
        restartButton.gameObject.SetActive(false);
    }

    public void AddShot()
    {
        shots++;

        if (shots >= maxShots)
        {
            restartButton.gameObject.SetActive(true);
        }

        UpdateScoreText();
    }

    public int GetShots()
    {
        return shots;
    }

    public void ShowScore(float distance)
    {
        int points;

        if (distance <= 0.25f)
        {
            points = 20;
        }
        else if (distance <= 0.75f)
        {
            points = 10;
        }
        else if (distance <= 1.25f)
        {
            points = 8;
        }
        else if (distance <= 1.75f)
        {
            points = 6;
        }
        else if (distance <= 2.25f)
        {
            points = 4;
        }
        else if (distance <= 2.75f)
        {
            points = 2;
        }
        else
        {
            points = 0;
        }

        totalScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + totalScore +
                         "\nShots: " + shots + " / " + maxShots;
    }

    public void RestartGame()
    {
        totalScore = 0;
        shots = 0;

        restartButton.gameObject.SetActive(false);

        targetMovement.ResetTarget();

        UpdateScoreText();
    }
}