
using System;
using UnityEngine;
public class ChangeColor : MonoBehaviour
{
    public static Color patientColor = new Color(128f,0f,11f);
    public static Color doctorColor = new Color(0f,35f,128f);
    [SerializeField] private Renderer myObject;
    
    public void ChangeMaterial (string player, string modifier)
    {
        float H, S, V;

        Color colorToChange = player == "doctor"? doctorColor: patientColor;
        Color.RGBToHSV(colorToChange, out H, out S, out V);
        V += modifier == "brighter"? 1: -1;
        V = Math.Max(19, V);
        if (player == "doctor")
        {
            doctorColor = Color.HSVToRGB(H, S, V);
            myObject.material.color = doctorColor;
        }
        else
        {
            patientColor = Color.HSVToRGB(H, S, V);
            myObject.material.color = patientColor;
        }

    }
    
}
