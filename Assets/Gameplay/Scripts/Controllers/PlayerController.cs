using Cysharp.Threading.Tasks;
using Gameplay.Models;
using Gameplay.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        private HUDView _hudView;

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

        public void SetCurrentWeapon(WeaponModel model)
        {
            Model.SetCurrentWeapon(model);
        }

        public void OnPlayerCollideWithWeaponRandomLoot(ILoot loot)
        {
            loot.ApplyEffect(_levelController, this);
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
            _levelController.RestartLevel();
        }

        private void OnPlayerLoseAllLives()
        {
            Debug.Log($"Game over, try again");
        }

        private void OnPlayerCollectsLoot(GameObject lootGO)
        {
            var loot = lootGO.GetComponent<LootViewBase>();
            Debug.Log($"loot collected: {loot.Type}");
            loot.Model.ApplyEffect(_levelController, this);
        }

        #endregion


        #region Unity callbacks

        private void Awake()
        {
            // Event Subscription
            _view.CollideWithBall += OnPlayerCollisionWithBall;
            _model.PlayerLoseLife += OnPlayerLoseLife;
            _model.PlayerLoseAllLives += OnPlayerLoseAllLives;
            _view.CollideWithLoot += OnPlayerCollectsLoot;

            _model.UpdateLives += _hudView.SetLivesText;
            _model.UpdatePoints += _hudView.SetScoreText;
            _model.UpdateWeaponName += _hudView.SetWeaponText;
        }


        private void OnDestroy()
        {
            _view.CollideWithBall -= OnPlayerCollisionWithBall;
            _model.PlayerLoseLife -= OnPlayerLoseLife;
            _model.PlayerLoseAllLives -= OnPlayerLoseAllLives;
            _view.CollideWithLoot -= OnPlayerCollectsLoot;

            _model.UpdateLives -= _hudView.SetLivesText;
            _model.UpdatePoints -= _hudView.SetScoreText;
            _model.UpdateWeaponName -= _hudView.SetWeaponText;

        }

        private void Start()
        {
            _hudView.SetLivesText(_model.Lives);
            _hudView.SetScoreText(_model.Score);
            _hudView.SetWeaponText(_model.Weapon.Name);
        }

        #endregion

        #region Tests

        [ContextMenu("Test/On Player Collision With Weapon Loot")]
        public void TestOnPlayerCollideWithWeaponRandomLoot()
        {
            WeaponController loot = new WeaponController(_levelController.Model.Weapons[1]); // Gun
            loot.ApplyEffect(_levelController, this);
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

        #region Properties

        public PlayerModel Model => _model;

        #endregion
    }
}