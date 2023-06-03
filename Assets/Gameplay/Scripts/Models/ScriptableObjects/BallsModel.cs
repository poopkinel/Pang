using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Models
{
    [CreateAssetMenu(menuName = "Pang Models/Balls Model", fileName = "Balls Model")]
    public class BallsModel : ScriptableObject
    {
        #region Static

        private static int lastId;

        #endregion

        #region Events

        public Action AllBallsDestroyed;

        #endregion

        #region Editor

        [SerializeField]
        private List<Ball> _balls = new List<Ball>();

        #endregion

        #region Methods

        public Ball GetBallById(int id)
        {
            return _balls.Find(b => b.Id == id);
        }
        
        public void DestroyBall(int id)
        {
            var ball = GetBallById(id);
            _balls.Remove(ball);

            if (IsAllBallsDestroyed)
            {
                AllBallsDestroyed?.Invoke();
            }
        }

        public void CreateBall(int hitsLeft, Vector2 position)
        {
            lastId = _balls.Max(b => b.Id) + 1;
            _balls.Add(new Ball(lastId, hitsLeft, position));
        }

        public Ball HitBall(int id)
        {
            if (_balls.Count(b => b.Id == id) == 0)
            {
                throw new ArgumentException("No such ball id in level");
            }

            var ball = GetBallById(id);
            return ball;
        }

        #endregion

        #region Properties

        public bool IsAllBallsDestroyed => _balls.Count <= 0;

        #endregion
    }
}