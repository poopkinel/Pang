using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.Infrastructure.Input
{
    [RequireComponent(typeof(Button))]
    public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Button _button;

        private bool _pressed;

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public bool IsPressed => _pressed;

        public Button ThisButton => _button;
    }
}