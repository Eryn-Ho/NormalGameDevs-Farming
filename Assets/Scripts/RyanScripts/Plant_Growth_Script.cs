using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Growth_Script : MonoBehaviour
{

    [SerializeField] private GameObject[] PlantStage;

    private int nextStage = 0;

    private bool seedPlanted = false;

    // Start is called before the first frame update
    void Start()
    {
        while (nextStage < PlantStage.Length)
        {
            PlantStage[nextStage].SetActive(false);
            nextStage++;
        }
        nextStage = 1;

    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            PlantSeed();
        }
        if (Input.GetKeyDown("s"))
        {
            PlantGrowth();
        }
    }

    public void PlantSeed()
    {
        if (seedPlanted == false)
        {
            PlantStage[0].SetActive(true);
            seedPlanted = true;
            Debug.Log("Seed planted");
        }
    }

    public void PlantGrowth()
    {
        // Set new plant stage and queue next plant stage
        if (seedPlanted == true)
        {
            PlantStage[nextStage].SetActive(true);
            if (nextStage == 0)
            {
                PlantStage[PlantStage.Length - 2].SetActive(false);
            }
            else
            {
                PlantStage[nextStage - 1].SetActive(false);
            }
            nextStage++;
            if (nextStage >= PlantStage.Length - 1)
            {
                nextStage = 0;
            }
            Debug.Log("plant stage" + nextStage);
        }


    }
}
