using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletObj;
    public float bulletForce = 10f;

    private void Update()
    {
        //shootDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //dir = (Vector2)((shootDir - transform.position));
        //dir.Normalize();

        if (Input.GetKeyUp(KeyCode.Space))
         {
            fireBullet();
        }
    }

    private void fireBullet()
    {
        GameObject bullet = Instantiate(bulletObj, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-transform.up * bulletForce, ForceMode2D.Impulse);
    }


}
