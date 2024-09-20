using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Growth_Script : MonoBehaviour
{
    [SerializeField] private MeshFilter PlantBase;
    [SerializeField] private Mesh[] PlantStage;

    private int nextStage;

    // Start is called before the first frame update
    void Start()
    {
        PlantBase.mesh = PlantStage[0];
        nextStage = 1;
    }
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            PlantGrowth();
        }
    }
    public void PlantGrowth()
    {
        // Set new plant stage and queue next plant stage
        PlantBase.mesh = PlantStage[nextStage];
        nextStage++;
        // Loop plant stage ( skips final stage aka death state )
        if (nextStage >= PlantStage.Length - 1)
        {
            nextStage = 0;
        }
        Debug.Log("plant stage" + nextStage);
    }
}
