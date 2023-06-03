using Gameplay.Models;
using General.Models;
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

    #endregion

    #region Methods

    [ContextMenu("Test/On Projectile Hit With Ball")]
    public void TetsOnProjectileHitWithBall()
    {
        var arbitraryId = 1; // for testing
        var arbPositionDestroyed = Vector2.zero; // for testing

        OnBallHit(arbitraryId, arbPositionDestroyed);
    }

    private void OnBallHit(int id, Vector2 positionHit)
    {
        var ball = _model.BallsModel.HitBall(id);

        if (!ball.IsLastHit)
        {
            _model.BallsModel.CreateBall(ball.HitsLeft - 1, positionHit);
            _model.BallsModel.CreateBall(ball.HitsLeft - 1, positionHit);
        }

        _model.BallsModel.DestroyBall(id);
    }

    private void OnTimerComplete()
    {
        if (!_model.BallsModel.IsAllBallsDestroyed)
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
        _timer.TimerComplete += OnTimerComplete;
        _model.BallsModel.AllBallsDestroyed += OnAllBallsDestroyed;
    }

    private void OnDestroy()
    {
        _timer.TimerComplete -= OnTimerComplete;
        _model.BallsModel.AllBallsDestroyed -= OnAllBallsDestroyed;
    }

    #endregion

    public LevelModel Model => _model;
}
