using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_scrpt : MonoBehaviour
{
    private LineRenderer lr;
    public Transform[] points;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
        SetUpLine(points);
    }

}
