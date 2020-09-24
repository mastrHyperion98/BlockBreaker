using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Cursor.visible = true;
       // throw a message that we lost the game
       SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
    }
}
