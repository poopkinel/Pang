using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Views
{
    public class LootViewBase : MonoBehaviour
    {
        [SerializeField]
        private LootType _type;

        [SerializeField]
        private ILoot _lootModel;

        public void SetModel(ILoot lootModel)
        {
            _lootModel = lootModel;
        }

        public ILoot Model => _lootModel;

        public LootType Type => _type;
    }
}