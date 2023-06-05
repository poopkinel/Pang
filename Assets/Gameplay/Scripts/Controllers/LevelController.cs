using Gameplay.Infrastructure;
using Gameplay.Infrastructure.Factories;
using Gameplay.Models;
using Gameplay.Views;
using General.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Gameplay.Controllers
{
    public class LevelController : MonoBehaviour
    {
        #region Events

        public Action AddScore;

        public Action BackButtonPressed;

        #endregion

        #region Editor

        [SerializeField]
        private LevelModel _model;

        [SerializeField]
        private GameModel _gameModel;

        [SerializeField]
        private Timer _timer;

        [SerializeField]
        private TimerView _timerView;

        [SerializeField]
        private TargetsViewManager _targetsViewManager;

        [SerializeField]
        private LootsViewManager _lootsViewManager;

        [SerializeField]
        private List<LootFactory> _lootFactories;

        [Header("UI Button")]
        [SerializeField]
        private Button _backButton;

        //[SerializeField]
        private LevelTargetsModel _runtimeTargetsModel;


        #endregion

        #region Methods

        public void RestartLevel()
        {
            SceneManager.LoadScene(_model.SceneIndex);
            _timer.SetStartTime(_model.TimeToFinish);
        }

        [ContextMenu("Test/On Projectile Hit With Ball")]
        public void TetsOnProjectileHitWithBall()
        {
            var arbitraryId = 1; // for testing
            var arbPositionDestroyed = Vector2.zero; // for testing

            OnTargetHitByProjectile(arbitraryId, arbPositionDestroyed);
        }

        public void OnProjectileHit(ProjectileView projView, GameObject hitGO, Vector2 hitPosition)
        {
            var target = hitGO.GetComponent<TargetView>();
            if (target != null)
            {
                OnTargetHitByProjectile(target.Id, hitPosition);
            }

            projView.ProjectileHit -= OnProjectileHit;
            Destroy(projView.gameObject);
        }

        private void OnTargetHitByProjectile(int id, Vector2 hitPosition)
        {
            HandleLootCreation(id, hitPosition);
            HandleTargetHit(id, hitPosition);

            AddScore?.Invoke();
        }

        private void HandleLootCreation(int id, Vector2 hitPosition)
        {
            var ball = _runtimeTargetsModel.GetTargetById(id);

            if (Random.Range(0, 1) > 0.1f) // Chance to get a loot
            {
                var factIndx = Random.Range(0, _lootFactories.Count);
                var loot = _lootFactories[factIndx].Create(hitPosition);
                _lootsViewManager.Create(loot, hitPosition);
            }
        }

        private void HandleTargetHit(int id, Vector2 hitPosition)
        {
            var target = _runtimeTargetsModel.GetTargetById(id);

            switch (target)
            {
                case Ball ball:
                    HandleBallHit(id, hitPosition, ball);
                    break;


                case Platform platform:
                    HandlePlatformHit(id, platform);
                    break;
            }
        }

        private void HandlePlatformHit(int id, Platform platform)
        {
            if (platform.HitsLeft == 0)
            {
                _runtimeTargetsModel.DestroyTarget(id);
                _targetsViewManager.DestroyTarget(id);
            }
            else
            {
                platform.TakeHit();
            }
        }

        private void HandleBallHit(int id, Vector2 hitPosition, Ball ball)
        {
            Vector2 startForceRight = new Vector2(1f, 1f) * 500000;
            Vector2 startForceLeft = new Vector2(-1f, 1f) * 500000;

            if (!ball.IsLastHit)
            {
                int ballOneId = _runtimeTargetsModel.CreateBall(ball.HitsLeft - 1);
                int ballTwoId = _runtimeTargetsModel.CreateBall(ball.HitsLeft - 1);

                var ballPrefab = _gameModel.BallsSizesToPrefabs.Find(p => p.size == ball.HitsLeft - 1).prefabRef;

                _targetsViewManager.CreateBall(ballPrefab, ballOneId, ball.HitsLeft, hitPosition, startForceRight);
                _targetsViewManager.CreateBall(ballPrefab, ballTwoId, ball.HitsLeft, hitPosition, startForceLeft);
            }

            _runtimeTargetsModel.DestroyTarget(id);
            _targetsViewManager.DestroyTarget(id);
        }

        private void OnTimerComplete()
        {
            foreach (PlayerModel player in _gameModel.Players)
            {
                player.LoseLife();

                if (player.Lives <= 0)
                {
                    new GameplayToGameOverScreenFlow(_model).Execute();
                    return;
                }
            }
            RestartLevel();
        }

        private void OnAllBallsDestroyed()
        {
            new EnterNextLevelFlow(_gameModel, _model).Execute();
        }

        private void OnBackButtonClicked()
        {
            BackButtonPressed?.Invoke();
            new FromGameplayToStartScreenFlow(_model).Execute();
        }

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            _runtimeTargetsModel = Instantiate(_model.ThisLevelTargetsModel); // Instantiate SO to have a runtime copy of the data

            _timer.TimerComplete += OnTimerComplete;
            _timer.TimerTick += _timerView.SetText;
            _timer.TimeSet += _timerView.SetText;
            _runtimeTargetsModel.AllBallsDestroyed += OnAllBallsDestroyed;

            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void Start()
        {
            _timer.StartTimer();
        }

        private void OnDestroy()
        {
            _timer.TimerComplete -= OnTimerComplete;
            _timer.TimerTick -= _timerView.SetText;
            _timer.TimeSet -= _timerView.SetText;

            _runtimeTargetsModel.AllBallsDestroyed -= OnAllBallsDestroyed;

            Destroy(_runtimeTargetsModel);

            _backButton.onClick.RemoveAllListeners();

        }

        #endregion

        #region Properties

        public LevelModel Model => _model;

        public GameModel ThisGameModel => _gameModel;

        #endregion
    }
}