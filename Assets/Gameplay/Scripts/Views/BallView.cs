using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField]
    private int _id;

    public void SetId(int id)
    {
        _id = id;
    }

    public int Id => _id;
}
