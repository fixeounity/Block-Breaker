using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // assign when changing state
    [SerializeField] Sprite broken1;
    [SerializeField] Sprite broken2;

    // states
    private int collisionCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collisionCount > 2)
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
        collisionCount++;
    }
}
