using Gameplay.Models;
using Gameplay.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private PlayerModel _model;

        [SerializeField]
        private PlayerView _view;

        [SerializeField]
        private LevelController _levelController;

        //[SerializeField]
        //private WeaponView weaponView;

        #endregion

        #region Methods

        public void Fire()
        {
            var projectile = _view.CreateProjectile(_model.Weapon.Prefab).GetComponent<ProjectileView>();
            projectile.SetSpeed(_model.Weapon.ProjectileSpeed);
            projectile.ProjectileHit += _levelController.OnProjectileHit;
        }

        public void Move(float horizontal)
        {
            _view.MoveHorizontal(horizontal);
        }

        public void OnPlayerCollideWithWeaponRandomLoot(ILoot loot)
        {
            loot.ApplyEffect(_levelController.Model, _model);
        }

        public void OnPlayerCollisionWithBall()
        {
            _model.LoseLife();
        }

        public void OnProjectileHitWithBall(int ballId)
        {
            int pointsToAdd = _levelController.Model.PointsForEachBallHit;
            _model.AddPoints(pointsToAdd);
        }

        private void OnPlayerLoseLife()
        {
            Debug.Log($"Player Lost Life");
        }

        private void OnPlayerLoseAllLives()
        {
            Debug.Log($"Game over, try again");
        }

        #endregion


        #region Unity callbacks

        private void Awake()
        {
            // Event Subscription
            _view.CollideWithBall += OnPlayerCollisionWithBall;
            _model.PlayerLoseLife += OnPlayerLoseLife;
            _model.PlayerLoseAllLives += OnPlayerLoseAllLives;
        }

        private void OnDestroy()
        {
            _view.CollideWithBall -= OnPlayerCollisionWithBall;
            _model.PlayerLoseLife -= OnPlayerLoseLife;
            _model.PlayerLoseAllLives -= OnPlayerLoseAllLives;
        }

        private void Start()
        {
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