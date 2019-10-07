using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSphereCommand : CommandInt
{
    Vector3 position;
    Transform sphere;

    public PlaceSphereCommand(Vector3 position, Transform sphere)
    {
        this.position = position;
        this.sphere = sphere;
    }

    void CommandInt.Execute()
    {
        CubePlacer.PlaceCube(position, sphere);
    }

    void CommandInt.Undo()
    {

    }
}