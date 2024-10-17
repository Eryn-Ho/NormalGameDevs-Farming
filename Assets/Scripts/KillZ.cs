using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZ : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y < -1)
        {
            transform.position = new Vector3(0, 0.2f, 0);
        }
    }
}
