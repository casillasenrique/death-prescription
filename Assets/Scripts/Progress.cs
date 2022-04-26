using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    
    public float loaded = 0;
    private GameObject progressPivot; 
    
    // Start is called before the first frame update
    void Start()
    {
        progressPivot = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        progressPivot.transform.localScale = new Vector3(-loaded, 1, 1);
    }
}
