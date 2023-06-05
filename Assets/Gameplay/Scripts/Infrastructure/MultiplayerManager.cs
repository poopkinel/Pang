using General.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Infrastructure
{
    public class MultiplayerManager : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private List<GameObject> _player2DependentObjects;

        [SerializeField]
        private GameModel _gameModel;

        #endregion

        #region Unity Callbacks

        void Start()
        {
            if (_gameModel.Players.Length == 1)
            {
                foreach (var go in _player2DependentObjects)
                {
                    go.SetActive(false);
                }
            }
        }

        #endregion
    }
}