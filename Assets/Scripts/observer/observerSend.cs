using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observerSend : MonoBehaviour
{
    //Singleton patton
    //creat a private instance to the scrip
    private static observerSend _instance;
    //The property to reture a instance
    public static observerSend Instance
    {
        //creat the object and assign the instance
        get
        {
            //create logic to make instance
            if (_instance == null)
            {
                GameObject go = new GameObject("observerSend");
                //get the object and add the scrip to it
                go.AddComponent<observerSend>();
            }
            return _instance;
        }
    }
    
     // when the object is loading we need to assign the instance
    private void Awake()
    {
        _instance = this;
    }


    //treat method as a variable and pass method as a variable for a callback. 
    //When it get called , it notifies all methods that reference the delegate.

    public delegate void Change(Color color);
    public static event Change changeRed;




    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            //check if anything is subscribe to the changeRed function
            if (changeRed != null)
            {
                //send the color to the observer
                changeRed(Color.black);
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //check if anything is subscribe to the changeRed function
            if (changeRed != null)
            {
                //send the color to the observer
                changeRed(Color.blue);
            }
        }
    }
}
