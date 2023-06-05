using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetView : MonoBehaviour
{
    [SerializeField]
    protected int _id;

    public virtual void SetId(int id)
    {
        _id = id;
    }

    public virtual int Id => _id;
}
