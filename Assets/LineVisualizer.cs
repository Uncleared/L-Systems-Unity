using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineVisualizer : LSystemVisualizer
{
    public int angle = 90;
    public float peak = 10f;
    public float length = 2f;
    public int iterations = 2;

    [ContextMenu("Visualize")]
    public override void GenerateVisuals()
    {
        LineRenderer lineRenderer = transform.GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        List<Vector3> points = new List<Vector3>();
        Vector3 currentPoint = Vector3.zero;
        Vector3 lastPoint = Vector3.zero;
        string sentence = lSystem.GenerateString(iterations);

        points.Add(currentPoint);

        int dir = -1;

        int n = 0;
        foreach (char c in sentence)
        {
            if(c.Equals('A'))
            {
                currentPoint += transform.forward * length;
            }
            else if(c.Equals('B'))
            {
                dir = -dir;
                currentPoint +=  (dir) * transform.right * peak;
                //currentPoint += Quaternion.Euler(0,90,0) * (currentPoint-lastPoint).normalized * length;
            }
            currentPoint = Quaternion.Euler(angle,0,0) * Quaternion.Euler(transform.up) * currentPoint;
            points.Add(currentPoint);
            n++;
        }
        lastPoint = currentPoint;
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
