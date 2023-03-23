using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToTarget : MonoBehaviour
{
    public GameObject myTarget;
    private Vector3 direction;
    public float moveSpeed;
    public float rotationSpeed = 1.0f;
    public Rigidbody2D rb;

    private void Start()
    {
        direction = myTarget.transform.position - transform.position;
        direction.Normalize();

    }



    // Update is called once per frame
    void Update()
    {
        float deltaSpeed = moveSpeed * Time.deltaTime;
        transform.Translate(direction.x * deltaSpeed, direction.y * deltaSpeed,
            direction.z * deltaSpeed, Space.World);


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -180 ;
        rb.rotation = angle;



    }
}
