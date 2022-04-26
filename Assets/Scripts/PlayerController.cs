using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Animator animator;
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (Main.gameOver)
        // {
        //     return;
        // }

        horizontalInput = Input.GetAxisRaw("Horizontal" + this.name);
        verticalInput = Input.GetAxisRaw("Vertical" + this.name);
        // Debug.Log(horizontalInput);
        rb.velocity = new Vector2(horizontalInput, verticalInput).normalized * speed;



        // Animation
        animator.SetFloat("MovementX", horizontalInput);
        animator.SetFloat("MovementY", verticalInput);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            // Only update the rotation if player is moving
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, rb.velocity) * Quaternion.Euler(0, 0, 90);
            this.transform.rotation = toRotation;
            animator.SetFloat("lastMovementX", horizontalInput);
            animator.SetFloat("lastMovementY", verticalInput);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision occurred");
        if (col.gameObject.name == "Doctor" || col.gameObject.name == "Patient")
        {
            Debug.Log("Doctor hit patient (or vice versa)");
            SceneManager.LoadScene("DoctorWin");
        }
    }
}
