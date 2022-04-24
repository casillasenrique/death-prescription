using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class Main : MonoBehaviour
{
    
    public GameObject exit;
    public Boolean generatorActive = false;

    private List<int> xPos = new List<int>() {751, 184, 1159, 1532, 1774, 1163, 1456, 1772, 1772, 1399, 1301};
    private List<int> yPos = new List<int>() {834, 924, 622, 622, 622, 404, 407, 407, 140, 140, 140}; 

    // Start is called before the first frame update
    void Start()
    {
        // Generate 2 random numbers
        Random rnd = new Random();
        int num = rnd.Next(0, xPos.Count);
        int num2 = num;
        while (num == num2)
        {
            num2 = rnd.Next(0, xPos.Count);
        }
        
        // Add the exits to the game
        Instantiate(exit, new Vector3(xPos[num], yPos[num], 0), Quaternion.identity);
        Instantiate(exit, new Vector3(xPos[num2], yPos[num2], 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
