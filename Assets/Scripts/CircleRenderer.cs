using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Light2DE = UnityEngine.Experimental.Rendering.Universal.Light2D;

public class CircleRenderer : MonoBehaviour
{

    public LineRenderer lineRenderer;
    [Range(6, 60)]   //creates a slider - more than 60 is hard to notice
    public int lineCount;       //more lines = smoother ring
    private float radius;
    public float width;

    public Light2DE flashlight;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.loop = true;
        radius = flashlight.pointLightOuterRadius;
        // Draw();
    }

    void Update() //Only need to draw when something changes
    {
        lineRenderer.positionCount = lineCount;
        lineRenderer.startWidth = width;
        float theta = (2f * Mathf.PI) / lineCount;  //find radians per segment
        float angle = 0;
        for (int i = 0; i < lineCount; i++)
        {
            float x = this.transform.position.x + radius * Mathf.Cos(angle);
            float y = this.transform.position.y + radius * Mathf.Sin(angle);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            //switch 0 and y for 2D games
            angle += theta;
        }
    }
}
