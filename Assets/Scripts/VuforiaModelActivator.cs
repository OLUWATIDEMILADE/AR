using UnityEngine;
using Lean.Touch;

public class VuforiaModelActivator : MonoBehaviour
{
    public GameObject customTrackerObject;   // Reference to the custom tracker in the scene
    public GameObject objectToActivate;      // The 3D model to show
    private bool hasActivated = false;

    private void Start()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // Start hidden
        }

        // Subscribe to LeanTouch tap event
        LeanTouch.OnFingerTap += HandleFingerTap;
    }

    private void OnDestroy()
    {
        LeanTouch.OnFingerTap -= HandleFingerTap;
    }

    private void HandleFingerTap(LeanFinger finger)
    {
        // Exit if already activated or required references are missing
        if (hasActivated || objectToActivate == null || customTrackerObject == null)
            return;

        // Cast a ray from the tap
        Ray ray = finger.GetRay();
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Activate only if the tapped object is the tracker
            if (hit.collider.gameObject == customTrackerObject)
            {
                objectToActivate.transform.position = customTrackerObject.transform.position;
                objectToActivate.SetActive(true);
                hasActivated = true;
            }
        }
    }
}
