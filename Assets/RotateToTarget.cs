using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    private Vector3 myTarget;
    public float rotationSpeed;
    private Vector2 direction;

    public float moveSpeed;


    // This update uses mouse position to rotate player
    //void Update()
    //{
    //    direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //    float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
    //    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //    transform.rotation = Quaternion.Slerp(transform.rotation , rotation, rotationSpeed * Time.deltaTime);
    //
    //
    //    Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed*Time.deltaTime);
    //}


    // This update uses keyboard keys to rotate
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
