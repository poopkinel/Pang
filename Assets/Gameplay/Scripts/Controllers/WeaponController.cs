using Gameplay.Controllers;
using Gameplay.Enums;
using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class WeaponController : ILoot
    {
        #region Private Fields

        private WeaponModel _model;

        #endregion

        #region Constructor

        public WeaponController(WeaponModel model)
        {
            _model = model;
        }

        #endregion

        #region Methods

        public void ApplyEffect(LevelController levelController, PlayerController playerController)
        {
            playerController.SetCurrentWeapon(_model);
        }

        #endregion

        #region Proprties

        public WeaponModel Model => _model;

        public LootType LootType => LootType.Weapon;

        #endregion
    }
}