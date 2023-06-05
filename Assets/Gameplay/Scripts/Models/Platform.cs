using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Gameplay.Models
{
    [System.Serializable]
    public class Platform : Target
    {
        public Platform(int id, int hitsLeft) : base(id, hitsLeft)
        {
        }

        public void TakeHit()
        {
            _hitsLeft--;
        }
    }

}