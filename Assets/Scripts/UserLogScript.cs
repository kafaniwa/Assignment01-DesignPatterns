using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserLogScript : MonoBehaviour
{
    string path;
    public float[] timerOut;
    public float[] timerIn;
    StreamWriter clear;
    StreamWriter Out;
    StreamReader In;

    void clearText()
    {
        clear = new StreamWriter(path + "/UserLog.txt", false);
        clear.Close();
    }
    void increTimer(float _deltaTime, int _index)
    {
        timerOut[_index] += _deltaTime;

        writeText();
    }
    void writeText()
    {
        clearText();
        Out = new StreamWriter(path + "/UserLog.txt", true);
        for (int i = 0; i <= 4; i++)
        { 
            Out.Write(timerOut[i] + " ");
        }
        Out.Close();
    }
    void readText()
    {
        In = new StreamReader(path + "/UserLog.txt", true);
        Debug.Log(In.ReadLine());
        In.Close();
    }

    void Start()
    {
        path = Application.dataPath;
        for (int i = 0; i <= 4; i++)
        {
            timerOut[i] = 0;
        }
        clearText();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            increTimer(Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            increTimer(Time.deltaTime, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            increTimer(Time.deltaTime, 2);
        }
        readText();
    }
}
