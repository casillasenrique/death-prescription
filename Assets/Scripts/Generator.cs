using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    
    Main mainRef;
    Progress progressRef;
    public GameObject patient;
    private double maxDistance = 20;

    
    // Start is called before the first frame update
    void Start()
    {
        patient = GameObject.Find("Patient");
        mainRef = GameObject.Find("Main Camera").GetComponent<Main>();
        progressRef = GameObject.Find("ProgressBar").GetComponent<Progress>();
        //Debug.Log("Found Main script");
    }

    // Update is called once per frame
    void Update()
    {

        double distance = Vector3.Distance(patient.transform.position, transform.position);
        //Debug.Log(distance);
        if (distance < maxDistance && progressRef.loaded < 1)
        {
            progressRef.loaded += 0.003f;
            // Debug.Log(progressRef.loaded);
            // Debug.Log("generator Turning on");
            mainRef.generatorTurningOn = true;
            if (progressRef.loaded >= 1)
            {
                mainRef.generatorActive = true;
                mainRef.generatorTurningOn = false;
                Debug.Log("Patient activated generator!");
                // TODO: add light flash
            }
        }
        else
        {
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
