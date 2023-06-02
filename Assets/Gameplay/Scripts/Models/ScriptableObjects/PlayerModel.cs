using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gameplay.Models
{
    [CreateAssetMenu(menuName = "Pang Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private int _score;

        [SerializeField]
        private int _lives;

        [SerializeField]
        private WeaponModel _weapon;

        public string Name => _name;

        public int Score => _score;

        public int Lives => _lives;

        public WeaponModel Weapon => _weapon;
    }
}
