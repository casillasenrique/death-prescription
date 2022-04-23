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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput, verticalInput) * speed;

        // Animation
        animator.SetFloat("MovementX", horizontalInput);
        animator.SetFloat("MovementY", verticalInput);

        if (horizontalInput != 0 || verticalInput != 0)
        {
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
