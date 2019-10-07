using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CylinderPlacer
{
    public static void PlaceCylinder(Vector3 position, Transform cylinder)
    {
        Transform newCylinder = GameObject.Instantiate(cylinder, position, Quaternion.identity);
    }
}
