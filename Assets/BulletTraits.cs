using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTraits : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }


}
