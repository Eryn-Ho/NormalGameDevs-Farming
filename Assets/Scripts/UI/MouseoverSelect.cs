using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// IPointerEnterHandler is an interface that lets our components listen to the pointer enter event from the UI
public class MouseoverSelect : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        // select this GameObject on pointer enter
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}