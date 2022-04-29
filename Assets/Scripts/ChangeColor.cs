
using System;
using UnityEngine;
using Light2DE = UnityEngine.Experimental.Rendering.Universal.Light2D;
using UnityEngine.UI;
public class ChangeColor : MonoBehaviour
{
    public static Color patientColor;
    public static Color doctorColor;
    public GameObject myObject;

    private void Start()
    {
        patientColor = new Color(1f,0f,0.04f);
        doctorColor = new Color(0,0.14f,1f);


    }
    public void ChangeMaterial (string playerModifier)
    {
        
        string[] playerModifierArray  = playerModifier.Split(' ');
        string player = playerModifierArray[0];
        string modifier = playerModifierArray[1];
        Color colorToChange = player == "doctor"? doctorColor: patientColor;
        

        Color filter = modifier == "brighter" ? new Color(1,1,1): new Color(0, 0, 0);
        float alpha = .15f;
        colorToChange.r += (filter.r - colorToChange.r) * alpha;
        colorToChange.g += (filter.g - colorToChange.g) * alpha;
        colorToChange.b += (filter.b - colorToChange.b) * alpha;


        Debug.Log(colorToChange);
        if (player == "doctor")
        {
            colorToChange.r = Math.Min(colorToChange.r,0);
            colorToChange.g = Math.Min(colorToChange.g, 0.14f);
            colorToChange.b = Math.Min(colorToChange.b, 1f);
            
            colorToChange.r = Math.Max(colorToChange.r,0);
            colorToChange.g = Math.Max(colorToChange.g, .073f);
            colorToChange.b = Math.Max(colorToChange.b, .522f);
            
            doctorColor = colorToChange;
            // myObject.material.color = doctorColor;
        }
        else
        {
            colorToChange.r = Math.Min(colorToChange.r,1);
            colorToChange.g = Math.Min(colorToChange.g, 0);
            colorToChange.b = Math.Min(colorToChange.b, .04f);
            
            colorToChange.r = Math.Max(colorToChange.r,.324f);
            colorToChange.g = Math.Max(colorToChange.g, 0);
            colorToChange.b = Math.Max(colorToChange.b, .034f);
            patientColor = colorToChange;
            // myObject.material.color = patientColor;
        }
        var light = myObject.GetComponent<Light2DE>();
        light.color = colorToChange;

    }
    
}
