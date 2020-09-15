using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    private float currentMousePosition;
    private const int screenWidth = 16;
    void Start()
    {
        currentMousePosition = Input.mousePosition.x / Screen.width * screenWidth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        // Every single frame we want to find the current position
        float mousePositionX = Input.mousePosition.x / Screen.width * screenWidth;
        float deltaX = currentMousePosition - mousePositionX;
        if(deltaX > 0)
              position += new Vector3(-deltaX, 0f,0f);
        else
            position -= new Vector3(deltaX, 0f,0f);

        gameObject.transform.position = position;
        currentMousePosition = mousePositionX;

    }
}
