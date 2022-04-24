using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    
    Main mainRef;
    
    // Start is called before the first frame update
    void Start()
    {
        mainRef = GameObject.Find("Main Camera").GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Something collided with the exit");

        if (col.gameObject.name == "Patient" && mainRef.generatorActive)
        {
            Debug.Log("Player escaped!");
            SceneManager.LoadScene("PatientWin");
        }
    }
}
