using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class UserLogDLL : MonoBehaviour
{
    const string DLL_NAME = "A1"; // <- change dll name to name of dll
    [DllImport(DLL_NAME)]
    private static extern void resetFile();
    [DllImport(DLL_NAME)]
    private static extern void increTimer(float _deltaTime, int _index, bool _continousSave);
    [DllImport(DLL_NAME)]
    private static extern void saveToFile();
    [DllImport(DLL_NAME)]
    private static extern void getFromFile();
    [DllImport(DLL_NAME)]
    private static extern float retriTimer(int _index);

    private void Start()
    {
        resetFile();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            increTimer(Time.deltaTime, 0, true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            increTimer(Time.deltaTime, 1, true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            increTimer(Time.deltaTime, 2, true);
        }

        Debug.Log("User pressed keys; W for " + retriTimer(0) + " seconds, A for " + retriTimer(1) + " seconds, D for " + retriTimer(2) + " seconds");
    }
}
