using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilling : MonoBehaviour
{
    [SerializeField] private GameObject _defaultGround;
    private void Start()
    {
        //_defaultGround = GetComponent<GameObject>(); 
        for (float xPos = -8.5f;  xPos < 8.5f; xPos += 1f)
        {
            
            for (float zPos = 5.5f; zPos > -6.5f; zPos -= 1f)
            {
                Instantiate (_defaultGround, new Vector3 (xPos, 0f , zPos), _defaultGround.transform.rotation);
                //Debug.Log("y loop");
            }
            

        }

    }
}
