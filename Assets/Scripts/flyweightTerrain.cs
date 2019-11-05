using UnityEngine;
using System.Collections;
using System;

public class flyweightTerrain : MonoBehaviour
{
    public Transform Spawner;
    public Material Mat1;
    public Material Mat2;

    flyweightTile Tile1;
    flyweightTile Tile2;
    flyweightTile[,] tiles;
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
            Tile1 = new flyweightTile(Mat1, true);
            Tile2 = new flyweightTile(Mat2, false);
            drawTerrain();
        }
    }

    void drawTerrain()
    {
        tiles = new flyweightTile[width, height];
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

class flyweightTile
{
    public flyweightTile(Material mat, bool isHard = false)
    {
        this.mat = mat;
        _ishard = ishard;
    }

    public Material mat;

    bool _ishard = false;

    public bool ishard
    {
        get { return _ishard; }
    }

}