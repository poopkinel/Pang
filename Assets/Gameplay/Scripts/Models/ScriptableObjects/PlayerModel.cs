using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay.Models
{
    [CreateAssetMenu(menuName = "Pang Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Events

        public Action PlayerLoseLife;
        public Action PlayerLoseAllLives;

        public Action<string> UpdateWeaponName;
        public Action<int> UpdateLives;
        public Action<int> UpdatePoints;

        #endregion

        #region Editor

        [SerializeField]
        private string _name;

        [SerializeField]
        private int _score;

        [SerializeField]
        private int _lives;

        [SerializeField]
        private WeaponModel _weapon;

        #endregion

        #region Public Methods

        public void SetCurrentWeapon(WeaponModel weapon)
        {
            _weapon = weapon;
            UpdateWeaponName?.Invoke(_weapon.Name);
        }

        public void SetLives(int lives)
        {
            _lives = lives;
            UpdateLives?.Invoke(_lives);

        }

        public void GainLife()
        {
            _lives++;
            UpdateLives?.Invoke(_lives);
        }

        public void LoseLife()
        {
            _lives--;
            PlayerLoseLife?.Invoke();

            if (_lives <= 0)
            {
                PlayerLoseAllLives?.Invoke();
            }
            UpdateLives?.Invoke(_lives);
        }

        public void AddPoints(int points)
        {
            _score += points;
            UpdatePoints?.Invoke(_score);
        }

        public void ResetLives()
        {
            _lives = 3;
        }

        public void ResetScore()
        {
            _score = 0;
            UpdatePoints?.Invoke(_score);
        }

        #endregion

        #region Properties

        public string Name => _name;

        public int Score => _score;

        public int Lives => _lives;

        public WeaponModel Weapon => _weapon;

        #endregion
    }
}
