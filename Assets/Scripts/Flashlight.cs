using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 movementVector = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.MovePosition(movementVector);
    }
}
