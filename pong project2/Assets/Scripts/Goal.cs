using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreText; // TextMeshPro for player 1's score
    public TextMeshProUGUI player2ScoreText; // TextMeshPro for player 2's score

    private int player1Score = 0;
    private int player2Score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (gameObject.CompareTag("Player1ScoreZone"))
            {
                player2Score++;
                UpdatePlayer2ScoreText(); 
            }
            else if (gameObject.CompareTag("Player2ScoreZone"))
            {
                player1Score++;
                UpdatePlayer1ScoreText();
            }

        }
    }

    private void UpdatePlayer1ScoreText()
    {
        if (player1ScoreText != null)
        {
            player1ScoreText.text = "" + player1Score;
        }
    }

    private void UpdatePlayer2ScoreText()
    {
        if (player2ScoreText != null)
        {
            player2ScoreText.text = "" + player2Score;
        }
    }
}
