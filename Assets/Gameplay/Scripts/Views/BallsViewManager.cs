using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsViewManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _ballPrefabRef;

    [SerializeField]
    private Transform _ballsParent;

    [SerializeField]
    private List<BallView> _ballViews = new ();

    public void Create(int ballId, Vector2 spawnPosition)
    {
        var ball = Instantiate(_ballPrefabRef, spawnPosition, Quaternion.identity, _ballsParent).GetComponent<BallView>();
        ball.SetId(ballId);
        _ballViews.Add(ball);
    }

    public void DestroyBall(int id)
    {
        var ball = _ballViews.Find(b => b.Id == id);
        Destroy(ball.gameObject);
    }
}
