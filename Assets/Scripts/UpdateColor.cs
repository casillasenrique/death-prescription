
using System;
using UnityEngine;
using Light2DE = UnityEngine.Experimental.Rendering.Universal.Light2D;
public class UpdateColor : MonoBehaviour
{
    // public GameObject myObject;
    [SerializeField] private string player;
    
    private void Start()
    {
        var light = this.GetComponent<Light2DE>();
        light.color = player == "doctor"? ChangeColor.doctorColor: ChangeColor.patientColor;
        
    }
    
}
