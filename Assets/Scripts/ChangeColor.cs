
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
        // patientColor = new Color(1, 0, 0);
        // doctorColor = new Color(0, 0, 1);


    }
    public void ChangeMaterial (string playerModifier)
    {
        string[] playerModifierArray  = playerModifier.Split(' ');
        string player = playerModifierArray[0];
        string modifier = playerModifierArray[1];
        Color colorToChange = player == "doctor"? doctorColor: patientColor;

        // if (modifier == "brighter")
        // {
        //     colorToChange.r += (255f-colorToChange.a)*.25f ;
        //     colorToChange.g += (255f-colorToChange.b)*.25f ;
        //     colorToChange.b += (255f-colorToChange.g)*.25f ;
        // }
        // else
        // {
        //     colorToChange.r *= .75f;
        //     colorToChange.g *=.75f;
        //     colorToChange.b *=.75f;
        // }

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
