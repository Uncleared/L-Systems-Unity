using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringVisualizer : LSystemVisualizer
{
    public int iterations = 1;
    [ContextMenu("Generate")]
    public override void GenerateVisuals()
    {
        print(lSystem.GenerateString(iterations));
    }
}
