using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driptrail : MonoBehaviour
{
  public GameObject bloodAsset;
  public float dripFreq = 2.0f; //how fast bloodstains spawn
  private float timer;
  // Start is called before the first frame update
  void Start()
  {
      timer = dripFreq;
  }

  // Update is called once per frame
  void Update()
  {
      timer -= Time.deltaTime;
      if(timer < 0){
        Instantiate(bloodAsset, transform);
        timer = dripFreq;
      }
  }
}
