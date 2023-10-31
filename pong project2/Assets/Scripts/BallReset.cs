using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class BallReset : MonoBehaviour
{
    public Transform initialPosition;  // The initial position of the ball
    public float minInitialForce = 2f; // Minimum force for the initial direction
    public float maxInitialForce = 5f; // Maximum force for the initial direction

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1ScoreZone") || other.CompareTag("Player2ScoreZone"))
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        // Reset the ball's position to the initial position
        transform.position = initialPosition.position;

        // Reset the ball's velocity to zero
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        // Give the ball a random initial force in a random direction
        float randomAngle = Random.Range(45f, 135f); // Angle range (45° to 135°)
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        float randomForce = Random.Range(minInitialForce, maxInitialForce);
        rb.AddForce(direction * randomForce, ForceMode2D.Impulse);
    }
}
