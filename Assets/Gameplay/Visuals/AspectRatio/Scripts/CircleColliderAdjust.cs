using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Visuals
{
    [RequireComponent(typeof(CircleCollider2D), typeof(RectTransform))]
    public class CircleColliderAdjust : MonoBehaviour
    {
        void Awake()
        {
            var rTrans = gameObject.GetComponent<RectTransform>();
            var x = rTrans.rect.width;

            gameObject.GetComponent<CircleCollider2D>().radius = x / 2;
        }
    }
}
