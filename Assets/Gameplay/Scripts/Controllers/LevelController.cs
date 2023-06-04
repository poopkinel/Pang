using Gameplay.Infrastructure;
using Gameplay.Infrastructure.Factories;
using Gameplay.Models;
using Gameplay.Views;
using General.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Gameplay.Controllers
{
    public class LevelController : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private LevelModel _model;

        [SerializeField]
        private Timer _timer;

        [SerializeField]
        private BallsViewManager _ballsViewManager;

        [SerializeField]
        private LootsViewManager _lootsViewManager;

        [SerializeField]
        private List<LootFactory> _lootFactories;

        [Header("UI Button")]
        [SerializeField]
        private Button _backButton;

        //[SerializeField]
        private BallsModel _runtimeBallsModel;


        #endregion

        #region Methods

        [ContextMenu("Test/On Projectile Hit With Ball")]
        public void TetsOnProjectileHitWithBall()
        {
            var arbitraryId = 1; // for testing
            var arbPositionDestroyed = Vector2.zero; // for testing

            OnBallHit(arbitraryId, arbPositionDestroyed);
        }

        public void OnProjectileHit(ProjectileView projView, GameObject hitGO, Vector2 hitPosition)
        {
            var ball = hitGO.GetComponent<BallView>();
            if (ball != null)
            {
                OnBallHit(ball.Id, hitPosition);
            }

            projView.ProjectileHit -= OnProjectileHit;
            Destroy(projView.gameObject);
        }

        private void OnBallHit(int id, Vector2 hitPosition)
        {
            HandleLootCreation(id, hitPosition);
            HandleBallCreateAndDestroy(id, hitPosition);
        }

        private void HandleLootCreation(int id, Vector2 hitPosition)
        {
            var ball = _runtimeBallsModel.GetBallById(id);

            if (Random.Range(0, 1) > 0.1f) // Chance to get a loot
            {
                var factIndx = Random.Range(0, _lootFactories.Count);
                var loot = _lootFactories[factIndx].Create(hitPosition);
                _lootsViewManager.Create(loot, hitPosition);
            }
        }

        private void HandleBallCreateAndDestroy(int id, Vector2 hitPosition)
        {
            var ball = _runtimeBallsModel.GetBallById(id);

            Vector2 startForceRight = new Vector2(1f, 1f) * 500000;
            Vector2 startForceLeft = new Vector2(-1f, 1f) * 500000;

            if (!ball.IsLastHit)
            {
                int ballOneId = _runtimeBallsModel.CreateBall(ball.HitsLeft - 1, hitPosition);
                int ballTwoId = _runtimeBallsModel.CreateBall(ball.HitsLeft - 1, hitPosition);

                _ballsViewManager.Create(ballOneId, ball.HitsLeft, hitPosition, startForceRight);
                _ballsViewManager.Create(ballTwoId, ball.HitsLeft, hitPosition, startForceLeft);
            }

            _runtimeBallsModel.DestroyBall(id);
            _ballsViewManager.DestroyBall(id);
        }

        private void OnTimerComplete()
        {
            if (!_runtimeBallsModel.IsAllBallsDestroyed)
            {
                Debug.Log("Level failed");
            }
        }

        private void OnAllBallsDestroyed()
        {
            Debug.Log($"Level complete!");
        }

        private void OnBackButtonClicked()
        {
            // stop level (timers, reset data, etc.)
            new FromGameplayToStartScreenFlow().Execute();
        }

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            _runtimeBallsModel = Instantiate(_model.BallsModel); // Instantiate SO to have a runtime copy of the data

            _timer.TimerComplete += OnTimerComplete;
            _runtimeBallsModel.AllBallsDestroyed += OnAllBallsDestroyed;

            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void Start()
        {

        }

        private void OnDestroy()
        {
            _timer.TimerComplete -= OnTimerComplete;
            _runtimeBallsModel.AllBallsDestroyed -= OnAllBallsDestroyed;

            Destroy(_runtimeBallsModel);

            _backButton.onClick.RemoveAllListeners();

        }

        #endregion

        public LevelModel Model => _model;

    }
}