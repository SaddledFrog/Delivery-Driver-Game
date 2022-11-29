using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float fastSpeed = 20f;
    [SerializeField] float slowSpeed = 3f;

    void Update()
    {
        float streerAmout = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmout = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -streerAmout);
        transform.Translate(0, moveAmout, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = fastSpeed;
        }
    }
}
