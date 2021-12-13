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
    [Range(0.05f, 10.0f)]
    private float lineStartWidth = 0.05f;

    [SerializeField]
    [Range(0.05f, 10.0f)]
    private float lineEndWidth = 0.05f;

    [SerializeField]
    [Range(1,1000)]
    private int numberOfPoints = 100;

    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float updateSeconds = 0.5f;

    private float interalTimer = 0;

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
        lineRenderer.startWidth = lineStartWidth;
        lineRenderer.endWidth = lineEndWidth;

        for(int i = 0; i < numberOfPoints; i++)
        {
            // i have to calculate the angle of the circle
            float angle = 2f * Mathf.PI / (float)numberOfPoints * i;

            float lineXPosition = Mathf.Cos(angle) * radius;
            float lineYPosition = Mathf.Sin(angle) * radius;

            //calculate its offset
            float offsetX = UnityEngine.Random.Range(lineXPosition, lineXPosition + (lineXPosition * randomOffset.x));
            float offsetY = UnityEngine.Random.Range(lineYPosition, lineYPosition + (lineYPosition * randomOffset.y));

            //apply a distance that is random

            //set the position on the line renderer
            lineRenderer.SetPosition(i, new Vector3(lineXPosition + offsetX, lineYPosition + offsetY, 0));

        }

        //close the circle by calculating the last point's position
        lineRenderer.SetPosition(numberOfPoints, new Vector3(lineRenderer.GetPosition(0).x, lineRenderer.GetPosition(0).y, 0));
    }

    void Update()
    {
        if(interalTimer >= updateSeconds)
        {
            DrawCircle();
            interalTimer = 0;
        }
        else
        {
            interalTimer = interalTimer + Time.deltaTime * 1.0f;
        }
    }
}
