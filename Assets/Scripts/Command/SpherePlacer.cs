using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpherePlacer
{
    public static void PlaceSphere(Vector3 position, Transform sphere)
    {
        Transform newSphere = GameObject.Instantiate(sphere, position, Quaternion.identity);
    }
}
