using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class ProGenLine : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f,10.0f)]
    private float radius = 1.0f;

    [SerializeField]
    private Vector2 randomOffset = Vector2.zero;

    [SerializeField]
    [Range(1,1000)]
    private int numberOfPoints = 100;

    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float updateSeconds = 0.5f;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        DrawCircle();
        //call on the draw circle function here

    }

    void DrawCircle()
    {
        lineRenderer.positionCount = numberOfPoints + 1;

        for(int i = 0; i < numberOfPoints; i++)
        {
            // i have to calculate the angle of the circle
            float angle = 2f * Mathf.PI / (float)numberOfPoints * i;

            float lineXPosition = Mathf.Cos(angle) * radius;
            float lineYPosition = Mathf.Sin(angle) * radius;

            //calculate its offset
            //apply a distance that is random

            //set the position on the line renderer
            lineRenderer.SetPosition(i, new Vector3(lineXPosition, lineYPosition, 0));

        }

        //close the circle by calculating the last point's position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
