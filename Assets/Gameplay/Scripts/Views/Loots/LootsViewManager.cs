using Gameplay.Enums;
using Gameplay.Models;
using Gameplay.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Views 
{
    [System.Serializable]
    public struct LootTypeToPrefab
    {
        public LootType lootType;
        public GameObject prefabRef;
    }

    public class LootsViewManager : MonoBehaviour
    {

        [SerializeField]
        private List<LootTypeToPrefab> _typesToPrefab;

        [SerializeField]
        private List<LootViewBase> _loots;

        [SerializeField]
        private Transform _lootParent;

        public void Create(ILoot loot, Vector2 position)
        {
            var prefab = _typesToPrefab.Find(t => t.lootType == loot.LootType).prefabRef;
            var lootGameObject = Instantiate(prefab, position, Quaternion.identity, _lootParent);
            lootGameObject.GetComponent<LootViewBase>().SetModel(loot);
        }
    }
}