using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[System.Serializable]
public class Platform : Target
{
    public Platform(int id, int hitsLeft, Vector2 SpawnPoint) : base(id, hitsLeft, SpawnPoint)
    {
    }
}

