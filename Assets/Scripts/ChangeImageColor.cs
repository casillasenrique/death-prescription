using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageColor : MonoBehaviour
{
    public string player;

    
    // Start is called before the first frame update
    void Awake()
    {
        // m_textMeshPro = gameObject.GetComponent<TextMeshPro>() ?? gameObject.AddComponent<TextMeshPro>();
        this.gameObject.GetComponent<Image>().color  = player == "doctor"? ChangeColor.doctorColor: ChangeColor.patientColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
