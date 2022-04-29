using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;
using Random = System.Random;

public class Main : MonoBehaviour
{
    public GameObject exit;
    public GameObject generator;
    public Boolean generatorTurningOn = false;
    public Boolean generatorActive = false;
    public GameObject patient;
    public GameObject doctor;

    private List<int> exXPos = new List<int>() {0, -560, 560, 0};
    private List<int> exYPos = new List<int>() {-483, -30, -30, 464};

    private List<int> genXPos = new List<int>() {0, 0, -70, 330, 330, -380};
    private List<int> genYPos = new List<int>() {-115, -310, 250, 235, -110, -95};

    public AudioSource bgmAudioSource;
    public AudioSource heartbeatSource;
    public AudioSource generatorAudioSource;
    public AudioClip backgroundMusicNormal;
    public AudioClip backgroundMusicGeneratorOn;
    public AudioClip heartbeatNormal;
    public AudioClip heartbeatFast;
    public AudioClip generatorSound;


    private double maxDistance = 200;

    private bool backgroundSoundSwitched = false;
    private bool heartbeatIsNormal = true;


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

        //Music To Game
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        bgmAudioSource.loop = true;
        bgmAudioSource.clip = backgroundMusicNormal;
        bgmAudioSource.volume = .1f;
        bgmAudioSource.Play();

        heartbeatSource = gameObject.AddComponent<AudioSource>();
        heartbeatSource.loop = true;
        heartbeatSource.clip = heartbeatNormal;
        heartbeatSource.volume = 1;
        heartbeatSource.Play();


        generatorAudioSource = gameObject.AddComponent<AudioSource>();
        generatorAudioSource.loop = true;
        generatorAudioSource.clip = generatorSound;
        generatorAudioSource.volume = .1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (generatorActive && !backgroundSoundSwitched)
        {
            Debug.Log("BGM SOUNDDDDD");
            bgmAudioSource.Stop();
            generatorAudioSource.Stop();
            bgmAudioSource.clip = backgroundMusicGeneratorOn;
            bgmAudioSource.Play();
            backgroundSoundSwitched = true;
        }

        //Players Heartbeat
        double distance = Vector3.Distance(patient.transform.position, doctor.transform.position);
        //Debug.Log(distance);

        //if within range, update sound to fast heart if haven't switched
        if (distance < maxDistance)
        {
            if (heartbeatIsNormal)
            {
                heartbeatIsNormal = false;
                heartbeatSource.clip = heartbeatFast;
                heartbeatSource.Play();
            }

        }
        else if (!heartbeatIsNormal)
        {
            heartbeatIsNormal = true;
            heartbeatSource.clip = heartbeatNormal;
            heartbeatSource.Play();
        }


        //Generator sounds
        if (generatorTurningOn && !generatorAudioSource.isPlaying)
        {
            Debug.Log("generator turning on");
            generatorAudioSource.Play();
        }
        else if (!generatorTurningOn)
        {
            generatorAudioSource.Pause();
        }
    }
}