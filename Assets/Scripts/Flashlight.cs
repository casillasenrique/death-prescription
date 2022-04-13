using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject doctor;
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
        // Get the rigid body
        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();

        // Make sure the flashlight is in the line of sight of the doctor
        // Adapted from http://answers.unity.com/answers/15638/view.html
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var rayDirection = doctor.transform.position - new Vector3(mousePosition.x, mousePosition.y, 0);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, rayDirection);

        if (hit.collider != null)
        {
            float distance = Vector2.Distance(hit.point, mousePosition);

            if (hit.collider.name == "Doctor")
            {
                Debug.Log("Did Hit");
                Debug.DrawRay(mousePosition, rayDirection, Color.yellow, Time.deltaTime);
                // Move the flashlight to the mouse position with smoothing

                // Adapted from https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/
                Vector2 movementVector = Vector2.SmoothDamp(
                    transform.position,
                    mousePosition,
                    ref currentVelocity,
                    smoothTime,
                    maxSpeed
                );

                rigidbody.MovePosition(movementVector);
            }
            else
            {
                Debug.Log("Did not Hit");
                Debug.DrawRay(mousePosition, rayDirection, Color.white, Time.deltaTime);
                rigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            // there is something obstructing the view
            Debug.DrawRay(mousePosition, rayDirection * 1000, Color.white, Time.deltaTime);
            Debug.Log("Did not Hit");
        }



    }
}
