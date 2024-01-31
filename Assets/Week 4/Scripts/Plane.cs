using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPositionThreshold = 0.2f;
    Vector2 LasPosition;
    LineRenderer lineRenderer;
    //aa

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosinion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(LasPosition, newPosinion) > newPositionThreshold)
        {
            points.Add(newPosinion);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosinion);
            LasPosition = newPosinion;
        }
    }
}
