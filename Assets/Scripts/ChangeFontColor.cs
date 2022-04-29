using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeFontColor : MonoBehaviour
{
    public string player;

    private TextMeshPro m_textMeshPro;
    // Start is called before the first frame update
    void Awake()
    {
        // m_textMeshPro = gameObject.GetComponent<TextMeshPro>() ?? gameObject.AddComponent<TextMeshPro>();
        this.gameObject.GetComponent<TextMeshProUGUI>().color = player == "doctor"? ChangeColor.doctorColor: ChangeColor.patientColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
