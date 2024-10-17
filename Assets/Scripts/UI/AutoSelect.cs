using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoSelect : MonoBehaviour
{
    private void Start()
    {
        // find attached selectable component and select it
        if(TryGetComponent(out Selectable selectable))
        {
            EventSystem.current.SetSelectedGameObject(null); // deselect current
            selectable.Select();
        }
    }

    private void OnEnable()
    {
        // find attached selectable component and select it
        if (TryGetComponent(out Selectable selectable))
        {
            EventSystem.current.SetSelectedGameObject(null); // deselect current
            selectable.Select();
        }
    }
}