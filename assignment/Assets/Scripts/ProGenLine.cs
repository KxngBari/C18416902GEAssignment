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
        //DrawCircle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
