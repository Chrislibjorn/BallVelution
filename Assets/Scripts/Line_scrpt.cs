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
    private void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
        lr.positionCount = points.Length;
    }

}
