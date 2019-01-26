using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // assign when changing state
    [SerializeField] Sprite broken1;
    [SerializeField] Sprite broken2;
    [SerializeField] AudioClip breakSound;

    // states
    private int collisionCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount++;
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        if (collisionCount > 2)
        {
            Destroy(gameObject);
        }
        else if(collisionCount == 1)
        {
            GetComponent<SpriteRenderer>().sprite = broken1;
        }
        else if (collisionCount == 2)
        {
            GetComponent<SpriteRenderer>().sprite = broken2;
        }
    }
}
