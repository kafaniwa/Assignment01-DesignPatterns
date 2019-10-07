using UnityEngine;

//Factory design pattern.
public class Factory : MonoBehaviour
{
    //Reference to prefab.
    [SerializeField]
    private MonoBehaviour prefab;

    public MonoBehaviour GetNewInstance()  // Creating new instance of prefab.
    {
        return Instantiate(prefab); // <returns>New instance of prefab
    }
}