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
        }

        public void GainLife()
        {
            _lives++;
        }

        public void LoseLife()
        {
            _lives--;
            PlayerLoseLife?.Invoke();

            if (_lives <= 0)
            {
                PlayerLoseAllLives?.Invoke();
            }
        }

        public void AddPoints(int points)
        {
            _score += points;
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
