using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Plant_Growth_Script : MonoBehaviour
{

    [SerializeField] private GameObject[] PlantStage;

    private int nextStage = 0;
    private bool dead = false;
    private int dayPlanted;
    private int plantLifeLength;
    private int plantLife = 1;
    private int dayCounter;
    private int mistakeCounter = 0;

    public bool seedPlanted = false;
    public int plant_ripe_length;
    public int mistakesAllowed;
    public bool waterTracker;

    public Day_tracker day_tracker;
    public garden_plot_state plot_state;

    // Start is called before the first frame update
    void Start()
    {
        while (nextStage < PlantStage.Length)
        {
            PlantStage[nextStage].SetActive(false);
            nextStage++;
        }
        nextStage = 1;
        plantLifeLength = (PlantStage.Length - 1) + plant_ripe_length;

        dayCounter = day_tracker.day;

        Debug.Log("Plant life length = " + plantLifeLength);

    }
   
    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            waterTracker = plot_state.watered;
            if (Input.GetKeyDown("a"))
            {
                PlantSeed();
            }
 
            if (dayCounter != day_tracker.day)
            {
                PlantGrowth();
                dayCounter++;
            }
        }
    }

    public void PlantSeed()
    {
        //Plants seed by unhiding currently used plant
        if ((seedPlanted == false) && (plot_state.tilled == true))
        {
            PlantStage[0].SetActive(true);
            seedPlanted = true;
            dayPlanted = day_tracker.day;
            Debug.Log("Seed planted on day " + dayPlanted);
        }
    }

    public void PlantGrowth()
    {
        // Set new plant stage and queue next plant stage
        if ((seedPlanted == true))
        {
            if (waterTracker == true)
            {
                // Plant grows till maturity then dies after plantLife = plantLifeLength
                if (plantLife != (plantLifeLength - 1))
                {
                    if (nextStage != PlantStage.Length - 1)
                    {
                        PlantStage[nextStage].SetActive(true);
                        PlantStage[nextStage - 1].SetActive(false);
                        nextStage++;
                    }
                    plantLife++;
                }
                else
                {
                    PlantStage[PlantStage.Length - 1].SetActive(true);
                    PlantStage[PlantStage.Length - 2].SetActive(false);
                    dead = true;
                }

                Debug.Log("plant stage" + nextStage);
                waterTracker = false;
            }
            else
            {
                // tracks days not watered and kills the plant if mistakes allowed is reached
                if (mistakeCounter == mistakesAllowed)
                {
                    PlantStage[PlantStage.Length - 1].SetActive(true);
                    PlantStage[nextStage - 1].SetActive(false);
                    dead = true;
                    Debug.Log("Plant is dead");
                }
                mistakeCounter++;

            }
        }


    }
}
