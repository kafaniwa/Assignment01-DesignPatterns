using UnityEngine;
using System.Collections;
using System;

public class flyweightPattern : MonoBehaviour
{
    public Transform Spawner;
    public Material Mat1;
    public Material Mat2;

    flyweight Tile1;
    flyweight Tile2;
    flyweight[,] tiles;
    int width = 5, height = 5;
    int[,] terrain = {
        { 0,1,0,0,0},
        { 0,0,0,1,0},
        { 1,0,0,1,0},
        { 1,0,0,0,0},
        { 0,0,1,0,0}
    };
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Tile1 = new flyweight(Mat1, true);
            Tile2 = new flyweight(Mat2, false);
            drawTerrain();
        }
    }

    void drawTerrain()
    {
        tiles = new flyweight[width, height];
        for (int q = 0; q < width; q++)
        {
            for (int p = 0; p < height; p++)
            {
                if (terrain[q, p] == 0)
                    tiles[q, p] = Tile2;
                else
                    tiles[q, p] = Tile1;
            }
        }

        for (int q = 0; q < width; q++)
        {
            for (int p = 0; p < height; p++)
            {
                GameObject gameobject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameobject.transform.position = new Vector3(q - 2, 0, p) + Spawner.position;
                gameobject.GetComponent<MeshRenderer>().material = tiles[q, p].mat;
            }
        }
    }
}