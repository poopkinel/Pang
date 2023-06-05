using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Models
{
    [CreateAssetMenu(menuName = "Pang Models/Level Targets Model", fileName = "Level Targets Model")]
    public class LevelTargetsModel : ScriptableObject
    {
        #region Static

        private static int lastId;

        #endregion

        #region Events

        public Action AllBallsDestroyed;

        #endregion

        #region Editor

        [SerializeField]
        private List<Ball> _balls;

        [SerializeField]
        private List<Platform> _platforms;

        #endregion

        #region Methods

        public Target GetTargetById(int id)
        {
            List<Target> targets = _balls.Concat<Target>(_platforms).ToList();

            if (targets.Count(t => t.Id == id) == 0)
            {
                throw new ArgumentException("No such target id in level");
            }

            return targets.Find(b => b.Id == id);
        }

        public void DestroyTarget(int id)
        {
            var target = GetTargetById(id);

            switch (target)
            {
                case Ball ball:
                    _balls.Remove(ball);
                    break;
                case Platform platform:
                    _platforms.Remove(platform);
                    break;
            }

            if (IsAllBallsDestroyed)
            {
                AllBallsDestroyed?.Invoke();
            }
        }

        public int CreateBall(int hitsLeft)
        {
            List<Target> targets = _balls.Concat<Target>(_platforms).ToList();

            lastId = targets.Max(b => b.Id) + 1;
            _balls.Add(new Ball(lastId, hitsLeft));
            return lastId;
        }

        #endregion

        #region Properties

        public bool IsAllBallsDestroyed => _balls.Count <= 0;

        #endregion
    }
}
