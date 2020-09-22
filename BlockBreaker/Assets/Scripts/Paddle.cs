using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    private const float screenWidth = 16f;
    private const float minUnit = 1f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        // Every single frame we want to find the current position
        float mousePositionX = Input.mousePosition.x / Screen.width * screenWidth;
        mousePositionX = Mathf.Clamp(mousePositionX, minUnit, screenWidth-minUnit);
        Vector2 paddlePos = new Vector2(mousePositionX, transform.position.y);
        transform.position = paddlePos;

    }
}
