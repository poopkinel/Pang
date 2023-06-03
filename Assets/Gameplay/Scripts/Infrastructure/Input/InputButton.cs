using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    public bool Pressed => _pressed;
}
