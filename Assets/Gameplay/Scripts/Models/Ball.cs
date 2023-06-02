using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ball
{
    [SerializeField]
    private int id;

    [SerializeField]
    private int hitsLeft;

    [SerializeField]
    private bool isDestroyed;

    [SerializeField]
    private Vector2 spawnPosition;
}
