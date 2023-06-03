using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Models
{
    [System.Serializable]
    public abstract class Target
    {
        protected static int lastId = 0;

        #region Editor

        [SerializeField]
        protected int _id;

        [SerializeField]
        protected int _hitsLeft;

        [SerializeField]
        protected Vector2 _spawnPosition;

        #endregion

        #region Constructor

        public Target(int id, int hitsLeft, Vector2 SpawnPoint)
        {
            _id = id;
            _hitsLeft = hitsLeft;
            _spawnPosition = SpawnPoint;
        }

        #endregion

        #region Properties

        public virtual int Id => _id;

        public virtual int HitsLeft => _hitsLeft;

        public virtual bool IsLastHit => _hitsLeft == 0;

        #endregion
    }
}