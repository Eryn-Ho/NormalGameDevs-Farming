using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tilling : MonoBehaviour
{
    //[SerializeField] private GameObject _defaultGround;
    [SerializeField] private GameObject _tilledPlot;
    [SerializeField] private float _displacement = 1f;
    public bool tillTool;
    private void Start()
    {
        //_defaultGround = GetComponent<GameObject>(); 
        for (float xPos = -8.5f;  xPos < 8.5f; xPos += 1f)
        {
            
            for (float zPos = 5.5f; zPos > -6.5f; zPos -= 1f)
            {
                //Instantiate (_defaultGround, new Vector3 (xPos, 0f , zPos), _defaultGround.transform.rotation);
                //Debug.Log("y loop");
            }
            

        }

    }

    private void OnInteract(InputValue value)
    {
        if (tillTool == true)
        {
            Instantiate(_tilledPlot, new Vector3(transform.position.x + _displacement, 0f, transform.position.z), _tilledPlot.transform.rotation);
        }
    }
}
