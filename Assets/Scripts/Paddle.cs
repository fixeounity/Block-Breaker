using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f;

    // Cached references
    Ball ball;
    GameSession gameSession;

	// Use this for initialization
	void Start () {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            float mousePosXInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnit;
            return mousePosXInUnits;
        }
    }
}
