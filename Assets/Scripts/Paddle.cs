using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minX = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mousePosXInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosXInUnits, minX, maxX);
        transform.position = paddlePos;
	}
}
