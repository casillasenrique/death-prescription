using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 500f;
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
        Debug.Log(horizontalInput);
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput, verticalInput) * speed;
    }

}
