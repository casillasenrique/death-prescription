using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    
    Main mainRef;
    Progress progressRef;
    public GameObject patient;
    public double maxDistance = 30;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        patient = GameObject.Find("Patient");
        mainRef = GameObject.Find("Main Camera").GetComponent<Main>();
        progressRef = GameObject.Find("ProgressBar").GetComponent<Progress>();
        animator = GetComponent<Animator>();
        //Debug.Log("Found Main script");
    }

    // Update is called once per frame
    void Update()
    {

        double distance = Vector3.Distance(patient.transform.position, transform.position);
        //Debug.Log(distance);
        // Player is close to the generator
        if (distance < maxDistance && progressRef.loaded < 1)
        {
            animator.SetBool("GeneratorStarting", true);
            progressRef.loaded += 0.002f;
            // Debug.Log(progressRef.loaded);
            // Debug.Log("generator Turning on");
            mainRef.generatorTurningOn = true;
            if (progressRef.loaded >= 1)
            {
                mainRef.generatorActive = true;
                mainRef.generatorTurningOn = false;
                animator.SetTrigger("GeneratorStarted");
                Debug.Log("Patient activated generator!");
                // TODO: add light flash
            }
        }
        else
        {
            // If the player stepped away but the progress is not done, play the
            // closing animation
            if (progressRef.loaded < 1) {
                animator.SetBool("GeneratorStarting", false);
            }

            mainRef.generatorTurningOn = false;
        }

        

    }
    
    // void OnTriggerEnter2D(Collider2D col)
    // {
    //     
    //     Debug.Log("generator collision");
    //     
    //     if (col.gameObject.name == "Patient")
    //     {
    //         mainRef.generatorActive = true;
    //         Debug.Log("Patient activated generator!");
    //         // TODO: add light flash
    //     }
    // }
}
