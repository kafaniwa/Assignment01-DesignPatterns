using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class SimplePluginTest : MonoBehaviour
{
    public Texture texture;
    public Texture texture2;
    const string DLL_NAME = "TESTPLUGIN";
    [DllImport(DLL_NAME)]
    private static extern void SimpleSaveFunction(float x, float y, float z);
    [DllImport(DLL_NAME)]
    private static extern float SimpleLoadFunctionX();
    [DllImport(DLL_NAME)]
    private static extern float SimpleLoadFunctionY();
    [DllImport(DLL_NAME)]
    private static extern float SimpleLoadFunctionZ();
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 100, 100, 100), texture))
        {

            SimpleSaveFunction(transform.position.x, transform.position.y, transform.position.z);
        }

        if (GUI.Button(new Rect(0, 200, 100, 100), texture2))
        {
            
            transform.position = new Vector3(SimpleLoadFunctionX(), 0.5f, SimpleLoadFunctionZ());
        }
    }
}
