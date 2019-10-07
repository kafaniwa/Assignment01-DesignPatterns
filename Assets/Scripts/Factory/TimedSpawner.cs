using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This is the spawner of the enemy. Component uses factory to spawn new instance every few moments
public class TimedSpawner : MonoBehaviour
{
    // Spawn rate
    [SerializeField]
    private float spawnRate = 30; //per minute
    private int currentCount = 0; //Current spawn count

    // Reference to used factory
    [SerializeField]
    private TimedObjectFactory factory;

    private void Update()
    {

        var targetCount = Time.time * (spawnRate / 60);
        while (targetCount > currentCount)
        {

            var inst = factory.GetNewInstance();
            inst.transform.position = new Vector3(Random.Range(-15.0f, 15.0f), 0.2f, Random.Range(-15.0f, 15.0f));
            currentCount++;

        }

    }
}
