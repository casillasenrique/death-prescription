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

    // Start is called before the first frame update
    void Start()
    {
        var light = this.GetComponent<Light2DE>();
        initialColor = light.color;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();
        var light = this.GetComponent<Light2DE>();


        // Compute a smooth damping movement vector that gives the next position
        // of the flashlight. Flashlight follows the mouse position.
        // Adapted from
        // https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var movementVector = mousePosition;
        // Vector2 movementVector = Vector2.SmoothDamp(
        //                 transform.position,
        //                 mousePosition,
        //                 ref currentVelocity,
        //                 smoothTime,
        //                 maxSpeed
        //             );

        // Make sure the flashlight is in the line of sight of the doctor using
        // a raycast from the flashlight position to the doctor position
        // Adapted from http://answers.unity.com/answers/15638/view.html
        var flashlightRayDirection = doctor.transform.position - new Vector3(movementVector.x, movementVector.y, 0);
        RaycastHit2D flashlightRaycast = Physics2D.Raycast(movementVector, flashlightRayDirection);

        if (flashlightRaycast.collider == null)
        {
            // No ray collision
            return;
        }

        // Check if the ray collides with the doctor first (before any walls)
        bool flashlightInLineOfSight = false;
        Color flashlightRayColor = Color.white;
        if (flashlightRaycast.collider.name == "Doctor")
        {
            flashlightInLineOfSight = true;
            flashlightRayColor = Color.yellow;
        }

        Debug.DrawRay(movementVector, flashlightRayDirection, flashlightRayColor, Time.deltaTime);


        if (flashlightInLineOfSight)
        {
            // Move the flashlight to the mouse position with smoothing
            light.intensity = 1;
            rigidbody.MovePosition(movementVector);
            return;
        }

        // IF the flashlight is not in line of sight with the doctor, turn off
        // the light
        rigidbody.MovePosition(movementVector);
        light.intensity = 0;
    }
}
