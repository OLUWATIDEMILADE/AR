using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaModelSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private bool hasSpawned = false;

    public void OnInteractiveHitTest(HitTestResult result)
    {
        if (!hasSpawned)
        {
            Instantiate(objectToSpawn, result.Position, result.Rotation);
            hasSpawned = true;
        }
    }
}
