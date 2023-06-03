using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gameplay.Views
{
    [System.Serializable]
    public struct BallSizesToPrefab
    {
        public int size;
        public GameObject prefabRef;
    }

    public class BallsViewManager : MonoBehaviour
    {
        [SerializeField]
        private List<BallSizesToPrefab> _ballPrefabRefs;

        [SerializeField]
        private Transform _ballsParent;

        [SerializeField]
        private List<BallView> _ballViews = new();

        public void Create(int ballId, int size, Vector2 spawnPosition, Vector2 startForce)
        {
            var prefabRef = _ballPrefabRefs.Find(p => p.size == size).prefabRef;
            var ball = Instantiate(prefabRef, spawnPosition, Quaternion.identity, _ballsParent).GetComponent<BallView>();

            ball.SetId(ballId);

            ball.GetComponent<Rigidbody2D>().AddForce(startForce);
            _ballViews.Add(ball);
        }

        public void DestroyBall(int id)
        {
            var ball = _ballViews.Find(b => b.Id == id);
            _ballViews.Remove(ball);
            Destroy(ball.gameObject);
        }
    }
}