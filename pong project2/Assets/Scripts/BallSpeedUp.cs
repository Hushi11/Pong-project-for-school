using UnityEngine;
using TMPro;

public class BallSpeedUp : MonoBehaviour
{
    public float initialSpeed = 5f; // The initial speed of the ball
    public float speedIncrease = 1f; // Amount to increase the speed after each bounce

    private Rigidbody2D rb;
    public TextMeshProUGUI player1ScoreText; // Reference to the player 1 score TextMeshPro
    public TextMeshProUGUI player2ScoreText; // Reference to the player 2 score TextMeshPro
    private int player1Score = 0;
    private int player2Score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = GetRandomInitialVelocity();
    }

    Vector2 GetRandomInitialVelocity()
    {
        // Get a random direction for the initial velocity
        float randomAngle = Random.Range(45f, 135f); // Angle range (45° to 135°)
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        return direction * initialSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a paddle or wall (you may need to tag them)
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            // Increase the speed of the ball after each bounce
            rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + speedIncrease);
        }
        else if (collision.gameObject.CompareTag("Player1ScoreZone"))
        {
            player1Score++;
            player1ScoreText.text = "Player1" + player1Score;
        }
        else if (collision.gameObject.CompareTag("Player2ScoreZone"))
        {
            player2Score++;
            player2ScoreText.text = "Player2" + player2Score;
        }
    }
}
