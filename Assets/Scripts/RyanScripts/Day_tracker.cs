using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_tracker : MonoBehaviour
{
    public int day;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Day " + day);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            day_increase();
        }
    }

    // Increases day by 1
    public void day_increase()
    {
        day++;
        Debug.Log("Day " + day);
    }
}
