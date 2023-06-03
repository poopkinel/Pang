using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gameplay.Infrastructure.Factories
{
    public class WeaponLootFactory : LootFactory
    {
        [SerializeField]
        private LevelModel _levelModel;

        public override ILoot Create(Vector2 position)
        {
            var possibleWeapons = _levelModel.Weapons;
            var weaponIndex = Random.Range(0, possibleWeapons.Length);
            var weapon = new WeaponController(possibleWeapons[weaponIndex]);
            return weapon;
        }
    }
}