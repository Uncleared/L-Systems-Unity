using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LSystemVisualizer : MonoBehaviour
{
    public LSystem lSystem;

    public abstract void GenerateVisuals();
}
