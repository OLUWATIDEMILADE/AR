using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    public Renderer objectRenderer;

    public void SetColorRed() => objectRenderer.material.color = Color.red;
    public void SetColorGreen() => objectRenderer.material.color = Color.green;
    public void SetColorBlue() => objectRenderer.material.color = Color.blue;
}