using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float smoothTime;
    public float maxSpeed;

    private Vector2 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("IgnoredByFlashlight");

        foreach (GameObject obj in objs)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Adapted from https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 movementVector = Vector2.SmoothDamp(
            transform.position,
            mousePosition,
            ref currentVelocity,
            smoothTime,
            maxSpeed
        );
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.MovePosition(movementVector);
    }
}
