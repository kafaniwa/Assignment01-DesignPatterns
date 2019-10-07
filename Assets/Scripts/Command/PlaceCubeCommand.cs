using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubeCommand : CommandInt
{
    Vector3 position;
    Transform cube;

    public PlaceCubeCommand(Vector3 position, Transform cube)
    {
        this.position = position;
        this.cube = cube;
    }

    void CommandInt.Execute()
    {
        CubePlacer.PlaceCube(position, cube);
    }

    void CommandInt.Undo()
    {
        CubePlacer.RemoveCube(position);
    }
}
