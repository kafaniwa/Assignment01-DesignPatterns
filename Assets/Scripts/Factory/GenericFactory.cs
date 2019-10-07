using UnityEngine;

//Generic Factory pattern to spawn differnt objects in futire
public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    private T prefab;  // Reference to prefab of whatever type.
    public T GetNewInstance()// Creating new instance of prefab.
    {
        return Instantiate(prefab); //Same as normal factory
    }
}