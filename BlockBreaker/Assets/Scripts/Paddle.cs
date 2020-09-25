﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    private const float screenWidth = 16f;
    private const float minUnit = 1.0f;
    [SerializeField] private float paddle_speed = 1.0f;
    private Vector2 paddlePos;
    void Start()
    {
        Cursor.visible = false;
        paddlePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Every single frame we want to find the current position
        float mousePositionX = (Input.mousePosition.x / Screen.width * screenWidth) * paddle_speed;
        mousePositionX = Mathf.Clamp(mousePositionX, minUnit, screenWidth-minUnit);
        paddlePos = new Vector2(mousePositionX, transform.position.y);
    }

    private void FixedUpdate()
    {
        transform.position = paddlePos;
    }
}
