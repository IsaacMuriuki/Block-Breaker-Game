using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // Cached references
    GameSession gameSession;
    Ball ball;


    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);

        // Ensures the paddle doesnt go over the limits of the play area
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);

        // Sets paddle position
        transform.position = paddlePosition; 
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            // Return mouse position
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
