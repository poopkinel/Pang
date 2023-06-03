using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Views
{
    public class LootViewBase : MonoBehaviour
    {
        [SerializeField]
        private LootType _type;

        public LootType Type => _type;
    }
}