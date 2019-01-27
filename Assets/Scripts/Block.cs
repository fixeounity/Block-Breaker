using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // assign when changing state
    [SerializeField] Sprite broken1;
    [SerializeField] Sprite broken2;
    [SerializeField] AudioClip breakSound;

    // states
    private int collisionCount = 0;

    // Cached references
    private Level currentLevel;
    private GameSession gameStatus;

    private void Start()
    {
        // Init cached references for multiple uses
        currentLevel = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();

        currentLevel.RegisterBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        currentLevel.BreakABlock();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount++;
        DestroyBlock();

        //else if(collisionCount == 1)
        //{
        //    GetComponent<SpriteRenderer>().sprite = broken1;
        //}
        //else if (collisionCount == 2)
        //{
        //    GetComponent<SpriteRenderer>().sprite = broken2;
        //}
    }
}
