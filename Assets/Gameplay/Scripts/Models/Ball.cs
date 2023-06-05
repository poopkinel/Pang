using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Models
{
    [System.Serializable]
    public class Ball : Target
    {
        public Ball(int id, int hitsLeft) : base(id, hitsLeft)
        {
        }
    }
}