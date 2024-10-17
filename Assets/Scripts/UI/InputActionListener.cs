using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionListener : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionReference;

    public UnityEvent OnPerformed;

    private void OnEnable()
    {
        // += behaves similar to the AddListener() function we used to listen to UnityEvents
        // the different here, is the 'performed' isn't a UnityEvent, it's a standard C# event
        if (_actionReference != null) _actionReference.action.performed += Performed;
    }

    private void OnDisable()
    {
        if (_actionReference != null) _actionReference.action.performed -= Performed;
    }

    // called whenever selected input is pressed by user
    private void Performed(InputAction.CallbackContext context)
    {
        OnPerformed.Invoke();
    }

    // allows us to invoke event from outside this script
    public void ForcePerform()
    {
        OnPerformed.Invoke();
    }
}
