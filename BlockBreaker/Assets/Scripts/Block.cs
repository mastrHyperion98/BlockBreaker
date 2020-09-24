using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private float NumberOfHits = 3;
    private int current_sprite_index = 0;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip BreakBlock;
    [SerializeField] private AudioClip ImpactBlock;
    [SerializeField] private Sprite[] array = new Sprite[3];

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag.CompareTo("Ball") != 0) return;
        NumberOfHits--;
        if (NumberOfHits == 0)
        { 
            _audioSource.PlayOneShot(BreakBlock);
            Destroy(this.gameObject);
                    
        }else
            _audioSource.PlayOneShot(ImpactBlock);

        ChangeSprite();
    }

    private void ChangeSprite()
    {
        current_sprite_index = Mathf.Clamp(current_sprite_index+1, 0, array.Length-1);
        _spriteRenderer.sprite = array[current_sprite_index];
    }
    
}
