using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    Camera mainCam;
    RaycastHit hit;
    Vector3 points;
    ManagerScript checker;

    public Transform cubePrefab;

    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    points.x = hit.point.x;
                    points.y = hit.point.y + 0.5f;
                    points.z = hit.point.z;

                    //CubePlacer.PlaceCube(points, cubePrefab);
                    CommandInt command = new PlaceCubeCommand(points, cubePrefab);
                    CommandInvoker.AddCommand(command);
                }
             }
    }
}
