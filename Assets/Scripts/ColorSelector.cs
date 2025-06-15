using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ColorSelector : MonoBehaviour
{
    public Renderer objectRenderer;

    private int colorIndex = 0;
    private Color[] colors = { Color.red, Color.green, Color.blue };

    private void Start()
    {
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        LeanTouch.OnFingerTap += HandleTap;
    }

    private void OnDestroy()
    {
        LeanTouch.OnFingerTap -= HandleTap;
    }

    private void HandleTap(LeanFinger finger)
    {
        Ray ray = finger.GetRay();
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if this GameObject was tapped
            if (hit.transform == transform)
            {
                // Cycle through colors on each tap
                colorIndex = (colorIndex + 1) % colors.Length;
                objectRenderer.material.color = colors[colorIndex];
            }
        }
    }

    // Optional manual color setters if still needed by UI
    public void SetColorRed() => objectRenderer.material.color = Color.red;
    public void SetColorGreen() => objectRenderer.material.color = Color.green;
    public void SetColorBlue() => objectRenderer.material.color = Color.blue;
}
