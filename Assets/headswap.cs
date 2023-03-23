using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headswap : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] headSprites;


    private void Start()
    {
        spriteRenderer.sprite = headSprites[Random.Range(0,headSprites.Length)];    
    }

    private void FixedUpdate()
    {
        if (transform.position.x < 0)
        {
            spriteRenderer.flipY = true;
        }
    }


}
