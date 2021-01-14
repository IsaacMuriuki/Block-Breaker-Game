using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparksVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;

    // State variables
    [SerializeField] int timesHit;  // Serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    // Initializes the number of breakable blocks
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    // Handles hits on blocks
    // Destroys block if the times hit is >= the max hits it can take
    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    // Shows the next hit sprite if the block requires > 1 hit to destroy it
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }

    }

    private void DestroyBlock()
    {
        // Play a sound on the camera's position when the block is collided with
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        // Adds to the total points when a block is destroyed
        FindObjectOfType<GameSession>().AddToScore();

        // Destroys block when it is hit by the ball
        Destroy(gameObject);

        // Decrement number of blocks when destroyed
        level.BlockDestroyed();

        // Trigger particle effects
        TriggerSparkleVFX();
    }

    // To make the particle effects
    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparksVFX, transform.position, transform.rotation);

        // Destroy sparkles after 1 second
        Destroy(sparkles, 1f);
    }
}
