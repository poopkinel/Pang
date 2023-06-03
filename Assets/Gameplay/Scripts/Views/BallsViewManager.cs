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

    private List<BallView> _ballViews;

    public void Create(int ballOneId, Vector2 spawnPosition)
    {
        var ball = Instantiate(_ballPrefabRef, spawnPosition, Quaternion.identity, _ballsParent);
        _ballViews.Add(ball.GetComponent<BallView>());
    }

    public void DestroyBall(int id)
    {
        var ball = _ballViews.Find(b => b.Id == id);
        Destroy(ball.gameObject);
    }
}
