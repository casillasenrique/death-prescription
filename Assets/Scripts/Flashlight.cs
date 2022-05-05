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
    private bool lightOn = true;

    private Color initialColor;

    private Light2DE light;
    
    public int lengthOfLineRenderer = 2;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light2DE>();
        initialColor = light.color;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.5f;
        lineRenderer.positionCount = lengthOfLineRenderer;
        lineRenderer.startColor = ChangeColor.doctorColor;
        lineRenderer.endColor = ChangeColor.doctorColor;
    }

    // Update is called once per frame
    void Update()
    {
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
        Vector2 docPos = doctor.transform.position;
        var flashlightRayDirection = docPos - new Vector2(movementVector.x, movementVector.y);
        //RaycastHit2D flashlightRaycast = Physics2D.Raycast(movementVector, flashlightRayDirection);
        RaycastHit2D flashlightRaycast = Physics2D.Raycast(doctor.transform.position, -flashlightRayDirection);

        //Debug.Log("name:" + flashlightRaycast.collider.name);
        //Debug.Log("flashlightRaycast.point:" + flashlightRaycast.point);
        Debug.DrawRay(movementVector, flashlightRayDirection, Color.yellow, Time.deltaTime);
        Vector2 flashPoint = Vector2.Distance(docPos, flashlightRaycast.point) >
                             Vector2.Distance(docPos, mousePosition)
            ? mousePosition : (flashlightRaycast.point + 7 * flashlightRayDirection.normalized);
        Debug.Log(flashPoint + " " + flashlightRaycast.point);
        //Debug.Log(flashlightRayDirection.normalized);
        //Debug.Log(Vector2.Distance(docPos, flashlightRaycast.point) >
        //          Vector2.Distance(docPos, mousePosition));
        
        GetComponent<Rigidbody2D>().MovePosition(flashPoint);
        if (Input.GetMouseButtonDown(0))
        {
            lightOn = !lightOn;
        }
        if (lightOn)
        {
            lineRenderer.SetPosition(0, doctor.transform.position);
            lineRenderer.SetPosition(1, doctor.transform.position);
            light.intensity = 1;
            return;
        }
        lineRenderer.SetPosition(0, doctor.transform.position);
        lineRenderer.SetPosition(1, flashPoint);
        light.intensity = 0;



        // if (flashlightRaycast.collider == null)
        // {
        //     // No ray collision
        //     return;
        // }
        //
        // // Check if the ray collides with the doctor first (before any walls)
        // bool flashlightInLineOfSight = false;
        // Color flashlightRayColor = Color.white;
        // if (flashlightRaycast.collider.name == "Doctor")
        // {
        //     flashlightInLineOfSight = true;
        //     flashlightRayColor = Color.yellow;
        // }
        //

        //
        //
        // if (flashlightInLineOfSight)
        // {
        //     // Move the flashlight to the mouse position with smoothing
        //     light.intensity = 1;
        //     rigidbody.MovePosition(movementVector);
        //     return;
        // }
        //
        // // IF the flashlight is not in line of sight with the doctor, turn off
        // // the light
        // rigidbody.MovePosition(movementVector);
        // light.intensity = 0;
    }
}
