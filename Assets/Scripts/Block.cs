using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // Config params
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    // states
    [SerializeField] int timesHit = 0;

    // Cached references
    private Level currentLevel;
    private GameSession gameStatus;

    private void Start()
    {
        // Init cached references for multiple uses
        currentLevel = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        if (tag == "Breakable")
        {
            currentLevel.CountBreakableBlocks();
        }
    }

    private void PlayBreakABlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        currentLevel.BreakABlock();
        gameStatus.AddToScore();
    }

    private void DestroyBlock()
    {
        PlayBreakABlock();

        TriggerSparklesVFX();

        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

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

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name+": Block sprite is missing from array ");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }
}
