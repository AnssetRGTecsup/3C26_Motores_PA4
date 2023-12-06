using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float radius;
    [SerializeField] private float lapsAmount;
    [SerializeField] private float angleStep;
    [SerializeField] private float altura;


    [Header("Line Render")]
    [SerializeField] private LineRenderer lineRenderer;

    [Header("Data")]
    [SerializeField] private float radiusStep;
    [SerializeField] private int _pivotPoints;

    
    private void Start()
    {
        _pivotPoints = (int)(360f / angleStep * lapsAmount);
        radiusStep = radius / lapsAmount / (360f / angleStep);
        angleStep = angleStep * Mathf.Deg2Rad;
        lineRenderer.positionCount = _pivotPoints;

        for (int i = 0; i < _pivotPoints; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Cos(angle) * radius;
            float y = i * altura;  // 0.01 funca bien xd
            float z = Mathf.Sin(angle) * radius;
            Vector3 position = new Vector3(x, y, z);
            lineRenderer.SetPosition(i, position);

            // reducir radio 
            radius -= radiusStep;
        }
    }
    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        DibujandoLine();
    //    }
    //}
    //void DibujandoLine()
    //{
    //    _pivotPoints = (int)(360f / angleStep * lapsAmount);
    //    radiusStep = radius / lapsAmount / (360f / angleStep);
    //    angleStep = angleStep * Mathf.Deg2Rad;
    //    lineRenderer.positionCount = _pivotPoints;

    //    for (int i = 0; i < _pivotPoints; i++)
    //    {
    //        float angle = i * angleStep;
    //        float x = Mathf.Cos(angle) * radius;
    //        float y = i * radiusStep;
    //        float z = Mathf.Sin(angle) * radius;
    //        Vector3 position = new Vector3(x, y, z);
    //        lineRenderer.SetPosition(i, position);
    //    }
    //}
}
