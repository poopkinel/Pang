using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Models
{
    public class Target
    {
        [SerializeField]
        private int _hitsLeft;

        [SerializeField]
        private bool _isDestroyed;

        public int HitsLeft => _hitsLeft;

        public bool IsDestroyed => _isDestroyed;
    }
}
