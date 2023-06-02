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

        #region Methods

        public void OnPlayerCollideWithWeaponRandomLoot(ILoot loot)
        {
            loot.ApplyEffect(_levelController.Model, _model);
        }

        public void OnPlayerCollisionWithBall()
        {
            _model.LoseLife();
        }

        public void OnProjectileHitWithBall()
        {
            int pointsToAdd = _levelController.Model.PointsForEachBallHit;
            _model.AddPoints(pointsToAdd);
        }

        #endregion

        #region Tests

        [ContextMenu("Test/On Player Collision With Weapon Loot")]
        public void TestOnPlayerCollideWithWeaponRandomLoot()
        {
            WeaponController loot = new WeaponController(_levelController.Model.Weapons[1]); // Gun
            loot.ApplyEffect(_levelController.Model, _model);
        }

        [ContextMenu("Test/On Player Collision With Ball")]
        public void TestOnPlayerCollisionWithBall()
        {
            _model.LoseLife();
        }

        [ContextMenu("Test/On Projectile Hit With Ball")]
        public void TetsOnProjectileHitWithBall()
        {
            int pointsToAdd = _levelController.Model.PointsForEachBallHit;
            _model.AddPoints(pointsToAdd);
        }

        #endregion
    }
}