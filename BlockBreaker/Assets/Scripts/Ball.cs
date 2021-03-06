﻿ using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Paddle paddle;
    private float initialYPosition;
    private bool isLaunched = false;
    private Rigidbody2D rigidBody;
    [SerializeField] private float velocity_speed;
    [SerializeField] AudioClip Impact;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        initialYPosition = transform.position.y;
        transform.position = new Vector2(paddle.transform.position.x, initialYPosition);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        if(!isLaunched)
            transform.position = new Vector2(paddle.transform.position.x, initialYPosition);
        if (!isLaunched && Input.GetKey(KeyCode.Space))
        {
            isLaunched = true;
            rigidBody.velocity = Vector2.up * velocity_speed;
        }
        
        rigidBody.velocity = velocity_speed * (rigidBody.velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag.CompareTo("Block") == 0)
            _audioSource.PlayOneShot(Impact);
    }
}
