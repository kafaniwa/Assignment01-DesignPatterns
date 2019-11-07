using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observerRecive : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        //Event that we can subscribe to,and for some method to call
        observerSend.changeRed += changeColor;

    }

    // The function to change object color
    // the function need to match the delegate void-color

    void changeColor(Color color)
    {
        transform.GetComponent<Renderer>().material.color = color;
    }


    // if the object nolonger exit, unsubscribe event
    private void OnDisable()
    {
        observerSend.changeRed -= changeColor;

    }
}
