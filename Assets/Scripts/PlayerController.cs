using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (Main.gameOver)
        // {
        //     return;
        // }

        horizontalInput = Input.GetAxis("Horizontal" + this.name);
        verticalInput = Input.GetAxis("Vertical" + this.name);
        // Debug.Log(horizontalInput);
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput, verticalInput) * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision occurred");
        if (col.gameObject.name == "Doctor" || col.gameObject.name == "Patient")
        {
            Debug.Log("Doctor hit patient (or vice versa)");
            SceneManager.LoadScene("GameEnd");
        }
    }

}
