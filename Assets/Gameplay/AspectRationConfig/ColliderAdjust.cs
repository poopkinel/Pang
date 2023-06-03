using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(RectTransform))]
public class ColliderAdjust : MonoBehaviour
{
    void Awake()
    {
        var rTrans = gameObject.GetComponent<RectTransform>();
        var x = rTrans.rect.width;
        var y = rTrans.rect.height;

        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(x, y);
    }
}
