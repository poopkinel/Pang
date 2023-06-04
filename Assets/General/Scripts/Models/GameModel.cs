using Gameplay.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace General.Models
{

    [CreateAssetMenu(menuName = "Pang Models/Game Model", fileName = "Game Model")]
    public class GameModel : ScriptableObject
    {
        [SerializeField]
        private int _highScore;

        [SerializeField]
        private LevelModel[] _levels;

        [SerializeField]
        private LevelModel _currentLevel;

        [SerializeField]
        private PlayerModel[] _players;

        public void SetPlayers(List<PlayerModel> players)
        {
            _players = players.ToArray();
        }

        public int HighScore => _highScore;
        
        public LevelModel[] Levels => _levels;

        public LevelModel CurrentLevel => _currentLevel;

        public PlayerModel[] Players => _players;
    }

}