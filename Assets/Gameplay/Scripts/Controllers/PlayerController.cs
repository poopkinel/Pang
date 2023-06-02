using Gameplay.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerModel _model;

        [SerializeField]
        private LevelController _levelController;

        //[SerializeField]
        //private WeaponView weaponView;

        private void Start()
        {
        }

        [ContextMenu("Test/OnPlayerCollisionWithWeaponLoot")]
        public void OnPlayerCollideWithWeaponRandomLoot()
        {
            WeaponController loot = new WeaponController(_levelController.Model.Weapons[1]); // Gun
            loot.ApplyEffect(_levelController.Model, _model);
        }

        //private void CollectLoot(WeaponLootModel weaponLoot)
        //{
        //    weaponLoot.ApplyEffect();
        //}
    }
}