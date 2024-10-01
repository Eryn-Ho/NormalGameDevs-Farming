using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garden_plot_state : MonoBehaviour
{
    public bool watered = false;
    public bool tilled = false;

    [SerializeField] private MeshFilter PlotBase;
    [SerializeField] private Material PlotWet;
    [SerializeField] private Mesh PlotTilled;

    private int dayCounter;

    public Day_tracker day_tracker;
    public Plant_Growth_Script plant_state;

    // Start is called before the first frame update
    void Start()
    {
        dayCounter = day_tracker.day;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") && (watered == false))
        {
            watering();
        }
        if (Input.GetKeyDown("2") && (tilled == false))
        {
            tilling();
        }
        // sets watered state to false after a day has passed. Extra if statement is to ensure growth is triggered before watered state is set to false if a seed has been planted
        if (plant_state.seedPlanted == true)
        {
            if ((dayCounter != day_tracker.day) && (plant_state.waterTracker == false))
            {
                watered = false;
                dayCounter++;
            }
        }
        else
        {
            if (dayCounter != day_tracker.day)
            {
                watered = false;
                dayCounter++;
            }
        }
    }

    public void watering()
    {
        watered = true;

        Debug.Log("Watered!");
    }

    public void tilling()
    {
        tilled = true;
        PlotBase.mesh = PlotTilled;
        Debug.Log("Tilled!");
    }

}