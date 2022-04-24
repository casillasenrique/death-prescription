using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    
    Main mainRef;
    
    // Start is called before the first frame update
    void Start()
    {
        mainRef = GameObject.Find("Main Camera").GetComponent<Main>();
        Debug.Log("Found Main script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Something collided with the exit");

        if (col.gameObject.name == "Patient")
        {
            mainRef.generatorActive = true;
            Debug.Log("Patient activated generator!");
            // TODO: add light flash
        }
    }
}
