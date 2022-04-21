using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    // Start is called before the first frame update
    public int timeUntilGone = 10;
    void Start()
    {
      Destroy(gameObject, timeUntilGone);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
