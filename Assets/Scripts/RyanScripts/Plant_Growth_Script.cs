using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Growth_Script : MonoBehaviour
{
    public MeshFilter PlantBase;
    public Mesh[] PlantStage;

    public int currentStage;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start debuggy");
        PlantBase.mesh = PlantStage[0];
    }
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlantBase.mesh = PlantStage[currentStage];
            currentStage++;
            if(currentStage >= PlantStage.Length)
            {
                currentStage = 0;
            }
            Debug.Log("Test key pressed!");
        }
    }
}
