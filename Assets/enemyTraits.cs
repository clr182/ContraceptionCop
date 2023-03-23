using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTraits : MonoBehaviour
{
    public GameObject splatSprite;


    private Transform pos;

    private void Start()
    {
        pos = this.transform;
    }

    private void Update()
    {    
        pos.position = this.gameObject.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<HeartSystem>().TakeDamage(1);
        }
    }

    private void leaveSplat()
    {
        Instantiate(splatSprite, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        Score.scoreNum += 100;
        leaveSplat();
    }

}
