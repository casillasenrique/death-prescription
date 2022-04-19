
using System;
using UnityEngine;
public class UpdateColor : MonoBehaviour
{
    [SerializeField] private Renderer myObject;
    [SerializeField] private string player;
    
    private void Start()
    {
        myObject.material.color = player == "doctor"? ChangeColor.doctorColor: ChangeColor.patientColor;
    }
    
}
