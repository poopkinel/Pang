using Gameplay.Models;
using General.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private LevelModel _model;

    [ContextMenu("Test/On Projectile Hit With Ball")]
    public void TetsOnProjectileHitWithBall()
    {
        var arbitraryId = 4; // for testing
        var arbPositionDestroyed = Vector2.zero; // for testing

        OnBallHit(arbitraryId, arbPositionDestroyed);
    }


    private void OnBallHit(int id, Vector2 positionHit)
    {
        var ball = _model.BallsModel.HitBall(id);

        if (!ball.IsSmallest)
        {
            _model.BallsModel.CreateBall(ball.HitsLeft - 1, positionHit);
            _model.BallsModel.CreateBall(ball.HitsLeft - 1, positionHit);
        }

        _model.BallsModel.DestroyBall(id);
    }

    public LevelModel Model => _model;
}
