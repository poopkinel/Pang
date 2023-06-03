using Gameplay.Infrastructure;
using Gameplay.Models;
using General.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private LevelModel _model;

    [SerializeField]
    private Timer _timer;

    [SerializeField]
    private BallsViewManager _ballsViewManager;

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
        var ball = _runtimeBallsModel.GetBallById(id);

        Vector2 startForceRight = new Vector2(1f, 0.2f) * 100000;
        Vector2 startForceLeft = new Vector2(-1f, 0.2f) * 100000;

        if (!ball.IsLastHit)
        {
            int ballOneId = _runtimeBallsModel.CreateBall(ball.HitsLeft - 1, hitPosition);
            int ballTwoId = _runtimeBallsModel.CreateBall(ball.HitsLeft - 1, hitPosition);

            _ballsViewManager.Create(ballOneId, hitPosition, startForceRight);
            _ballsViewManager.Create(ballTwoId, hitPosition, startForceLeft);
        }

        _runtimeBallsModel.DestroyBall(id);
        _ballsViewManager.DestroyBall(id);
    }

    private void OnBallHitView(int id)
    {

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

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        _runtimeBallsModel = Instantiate(_model.BallsModel); // Instantiate SO to have a runtime copy of the data

        _timer.TimerComplete += OnTimerComplete;
        _runtimeBallsModel.AllBallsDestroyed += OnAllBallsDestroyed;
    }

    private void Start()
    {
        
    }

    private void OnDestroy()
    {
        _timer.TimerComplete -= OnTimerComplete;
        _runtimeBallsModel.AllBallsDestroyed -= OnAllBallsDestroyed;

        Destroy(_runtimeBallsModel);
    }

    #endregion

    public LevelModel Model => _model;

}
