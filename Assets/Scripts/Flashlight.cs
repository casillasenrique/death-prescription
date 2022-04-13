using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Light2DE = UnityEngine.Experimental.Rendering.Universal.Light2D;
public class Flashlight : MonoBehaviour
{
    public GameObject doctor;
    public float smoothTime;
    public float maxSpeed;

    private Vector2 currentVelocity;

    private Color initialColor;

    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        var light = this.GetComponent<Light2DE>();
        collider = this.GetComponent<Collider2D>();
        initialColor = light.color;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("IgnoredByFlashlight");

        foreach (GameObject obj in objs)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();
        var light = this.GetComponent<Light2DE>();


        // Adapted from http://answers.unity.com/answers/15638/view.html
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 movementVector = Vector2.SmoothDamp(
                        transform.position,
                        mousePosition,
                        ref currentVelocity,
                        smoothTime,
                        maxSpeed
                    );


        // Vector3 futurePosition = this.transform.position + new Vector3(movementVector.x, movementVector.y, 0);

        // Make sure the flashlight is in the line of sight of the doctor
        var mouseRayDirection = doctor.transform.position - new Vector3(mousePosition.x, mousePosition.y, 0);
        var flashlightRayDirection = doctor.transform.position - new Vector3(movementVector.x, movementVector.y, 0);
        RaycastHit2D mouseRaycast = Physics2D.Raycast(mousePosition, mouseRayDirection);
        RaycastHit2D flashlightRaycast = Physics2D.Raycast(movementVector, flashlightRayDirection);

        if (flashlightRaycast.collider == null)
        {
            return;
        }

        bool flashlightInLineOfSight = false;
        Color mouseRayColor = Color.white;
        Color flashlightRayColor = Color.white;

        if (mouseRaycast.collider.name == "Doctor")
        {
            mouseRayColor = Color.yellow;
        }

        if (flashlightRaycast.collider.name == "Doctor")
        {
            flashlightInLineOfSight = true;
            flashlightRayColor = Color.yellow;
        }

        Debug.DrawRay(mousePosition, mouseRayDirection, mouseRayColor, Time.deltaTime);
        Debug.DrawRay(movementVector, flashlightRayDirection, flashlightRayColor, Time.deltaTime);



        if (flashlightInLineOfSight)
        {
            // Move the flashlight to the mouse position with smoothing
            // Adapted from
            // https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/
            collider.enabled = true;
            light.color = initialColor;
            rigidbody.MovePosition(movementVector);
            return;
        }

        rigidbody.MovePosition(movementVector);
        light.color -= (Color.white / 0.05f) * Time.deltaTime;
        // rigidbody.MovePosition(mousePosition);
        collider.enabled = false;
    }

    void moveTowards(Vector2 target)
    {
        // Get the rigid body
        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();

        Vector2 movementVector = Vector2.SmoothDamp(
                        transform.position,
                        target,
                        ref currentVelocity,
                        smoothTime,
                        maxSpeed
                    );

        rigidbody.MovePosition(movementVector);
    }

    void stopMoving()
    {
        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.zero;
    }
}
