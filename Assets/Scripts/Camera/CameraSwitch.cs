using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera topCamera;
    public Camera characterCamera;
    Camera activeCamera;
    public Texture texture;

    // Start is called before the first frame update
    void Start()
    {
        //topCamera = Camera.main;
        topCamera.enabled = true;
        characterCamera.enabled = false;
    }

    public Camera GetActiveCamera()
    {
        return activeCamera;
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), texture))
        {
            topCamera.enabled = !topCamera.isActiveAndEnabled;
            characterCamera.enabled = !characterCamera.isActiveAndEnabled;
            if (topCamera.enabled)
                //topCamera = Camera.main;
                activeCamera = topCamera;
            else if (characterCamera.enabled)
                //characterCamera = Camera.main;
                activeCamera = characterCamera;
            else print("Camera logic error");
        }
    }
}
