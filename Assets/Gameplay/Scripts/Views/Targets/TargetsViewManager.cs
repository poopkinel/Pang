using Gameplay.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gameplay.Views
{
    public class TargetsViewManager : MonoBehaviour
    {
        [SerializeField]
        private Transform _targetsParent;

        [SerializeField]
        private List<TargetView> _targetViews = new();

        public void CreateBall(GameObject prefab, int ballId, int size, Vector2 spawnPosition, Vector2 startForce)
        {
            var ball = Instantiate(prefab, spawnPosition, Quaternion.identity, _targetsParent).GetComponent<BallView>();

            ball.SetId(ballId);

            ball.GetComponent<Rigidbody2D>().AddForce(startForce);
            _targetViews.Add(ball);
        }

        public void DestroyTarget(int id)
        {
            var target = _targetViews.Find(t => t.Id == id);
            _targetViews.Remove(target);
            Destroy(target.gameObject);
        }
    }
}