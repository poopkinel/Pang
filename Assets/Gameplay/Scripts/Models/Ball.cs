using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ball : Target
{
    public Ball(int id, int hitsLeft, Vector2 SpawnPoint) : base(id, hitsLeft, SpawnPoint)
    {
    }
}
