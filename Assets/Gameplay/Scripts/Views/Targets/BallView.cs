using System;
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

    internal void SetSize(int size)
    {
        throw new NotImplementedException();
    }

    public int Id => _id;
}
