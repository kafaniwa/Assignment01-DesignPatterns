using UnityEngine;
// Timeout object, that destroys itself after provided timeout.
public class TimeoutObject : MonoBehaviour
{
    // Time after which object will be destroyed
    [SerializeField]
    private float timeout = 2;
    // Saving enable time to calculate when to destroy itself
    private float startTime;
    private void OnEnable() // Unity's method called on object enable
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - startTime > timeout) // Waiting for timeout
        {
            Destroy(gameObject); // Destroying object
        }
    }
}