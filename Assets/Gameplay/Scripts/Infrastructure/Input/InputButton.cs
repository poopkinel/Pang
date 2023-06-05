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
        #region Editor

        [SerializeField]
        private Button _button;

        #endregion

        #region Private Fields

        private bool _pressed;

        #endregion

        #region Callbacks

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
        }

        #endregion

        #region Properties

        public bool IsPressed => _pressed;

        public Button ThisButton => _button;

        #endregion
    }
}