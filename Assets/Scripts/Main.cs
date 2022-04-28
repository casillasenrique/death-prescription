using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class Main : MonoBehaviour
{
    
    public GameObject exit;
    public GameObject generator;
    public Boolean generatorActive = false;

    private List<int> exXPos = new List<int>() {0, -560, 560, 0};
    private List<int> exYPos = new List<int>() {-483, -30, -30, 464}; 
    
    private List<int> genXPos = new List<int>() {0, 0, -70, 330, 330, -380};
    private List<int> genYPos = new List<int>() {-115, -310, 250, 235, -110, -95}; 

    // Start is called before the first frame update
    void Start()
    {
        // Generate 2 random numbers
        Random rnd = new Random();
        int ex1 = rnd.Next(0, exXPos.Count);
        int ex2 = ex1;
        int gen1 = rnd.Next(0, genXPos.Count);
        int gen2 = gen1;
        while (ex1 == ex2)
        {
            ex2 = rnd.Next(0, exXPos.Count);
        }
        
        while (gen1 == gen2)
        {
            gen2 = rnd.Next(0, genXPos.Count);
        }

        // Add the exits to the game
        Instantiate(exit, new Vector3(exXPos[ex1], exYPos[ex1], 0), Quaternion.identity);
        Instantiate(exit, new Vector3(exXPos[ex2], exYPos[ex2], 0), Quaternion.identity);
        Instantiate(generator, new Vector3(genXPos[gen1], genYPos[gen1], 0), Quaternion.identity);
        Instantiate(generator, new Vector3(genXPos[gen2], genYPos[gen2], 0), Quaternion.identity);
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
