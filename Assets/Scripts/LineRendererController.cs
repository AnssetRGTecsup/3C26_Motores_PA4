using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float radius;
    [SerializeField] private float lapsAmount;
    [SerializeField] private float angleStep;

    [Header("Line Render")]
    [SerializeField] private LineRenderer lineRenderer;

    [Header("Data")]
    [SerializeField] private float radiusStep;
    [SerializeField] private int _pivotPoints;

    private void Start()
    {
        _pivotPoints = (int) (360f / angleStep * lapsAmount);

        radiusStep = radius / lapsAmount / (360f / angleStep);

        angleStep = angleStep * Mathf.Deg2Rad;

        lineRenderer.positionCount = _pivotPoints;

        for (int i = 0; i < _pivotPoints; i++)
        {
            Vector3 position = new Vector3(0f, 0f, 0f);
            lineRenderer.SetPosition(i, position);
        }
    }
}
