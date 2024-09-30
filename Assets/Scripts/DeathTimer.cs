using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    float time = 0f;
    float timeLimit = 2f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeLimit ) Destroy(gameObject);    
    }
}
