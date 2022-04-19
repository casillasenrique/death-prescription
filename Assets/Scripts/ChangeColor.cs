
using System;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColor : MonoBehaviour
{
    public static Color patientColor;
    public static Color doctorColor;
    [SerializeField] private Renderer myObject;

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
            doctorColor = colorToChange;
            myObject.material.color = doctorColor;
        }
        else
        {
            patientColor = colorToChange;
            myObject.material.color = patientColor;
        }

    }
    
}
