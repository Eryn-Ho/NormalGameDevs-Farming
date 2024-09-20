using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garden_plot_state : MonoBehaviour
{
    private bool watered_state = false;
    private bool tilled_state = false;

    [SerializeField] private MeshFilter PlotBase;
    [SerializeField] private Material PlotWet;
    [SerializeField] private Mesh PlotTilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") && (watered_state = false))
        {
            watering();
        }
        if (Input.GetKeyDown("2") && (tilled_state = false))
        {
            tilling();
        }
    }

    public void watering()
    {
        watered_state = true;

        Debug.Log("Watered!");
    }

    public void tilling()
    {
        tilled_state = true;
        PlotBase.mesh = PlotTilled;
        Debug.Log("Tilled!");
    }

}