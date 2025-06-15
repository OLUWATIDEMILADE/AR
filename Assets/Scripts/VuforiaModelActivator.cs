using UnityEngine;
using Lean.Touch;

public class VuforiaModelActivator : MonoBehaviour
{
    public GameObject customTrackerObject;   // The tracker prefab in the scene (custom plane indicator)
    public GameObject objectToActivate;      // Your 3D model prefab in the scene (set inactive)
    private bool hasActivated = false;

    private void Start()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // Ensure the 3D model is hidden at start
        }

        // Subscribe to LeanTouch's tap event
        LeanTouch.OnFingerTap += HandleFingerTap;
    }

    private void OnDestroy()
    {
        LeanTouch.OnFingerTap -= HandleFingerTap;
    }

    private void HandleFingerTap(LeanFinger finger)
    {
        if (hasActivated || objectToActivate == null || customTrackerObject == null)
            return;

        // Raycast from the touch into the scene
        Ray ray = finger.GetRay();
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the user tapped the custom tracker object
            if (hit.collider.gameObject == customTrackerObject)
            {
                objectToActivate.transform.position = customTrackerObject.transform.position;
                objectToActivate.SetActive(true);
                hasActivated = true;
            }
        }
    }
}
