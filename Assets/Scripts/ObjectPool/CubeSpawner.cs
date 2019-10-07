using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    ObjectPooler op;

    private void Start()
    {
        op = ObjectPooler.Instance;

    }

    void FixedUpdate()
    {
        if (Input.GetKey("p"))
        {
            op.SpawnFromPool("cube", transform.position, Quaternion.identity);
        }
    }
}