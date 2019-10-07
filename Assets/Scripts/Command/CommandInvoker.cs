using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<CommandInt> commandBuffer;

    static List<CommandInt> commandHistory;
    static int counter;

    private void Awake()
    {
        commandBuffer = new Queue<CommandInt>();
        commandHistory = new List<CommandInt>();
    }

    public static void AddCommand(CommandInt command)
    {
        if (counter < commandHistory.Count)
        {
            while (commandHistory.Count > counter)
            {
                commandHistory.RemoveAt(counter);
            }
        }
        commandBuffer.Enqueue(command);
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            CommandInt c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Cammand history length: " + commandHistory.Count);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                }
            }
        }
    }
}