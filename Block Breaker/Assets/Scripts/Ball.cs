using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // Configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 2f;

    // State 
    Vector2 paddleToBallVector; // Distance between paddle and ball
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    // Sticks the ball to the paddle before the game starts
    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y); // Accessing the paddles position
        transform.position = paddlePosition + paddleToBallVector;
    }


    // Launches the ball off the paddle at the start of a game
    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;

            // Accessing the velocity of the rigid body component
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }

    }

    // Plays audio clip on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Tweaks the velocity by a random factor to avoid ball path loops
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            // Plays audio only if game has started
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);

            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
