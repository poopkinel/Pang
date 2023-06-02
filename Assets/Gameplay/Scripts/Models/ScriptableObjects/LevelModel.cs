using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Models
{
    [CreateAssetMenu(menuName = "Pang Models/Level Model", fileName = "Level Model")]
    public class LevelModel : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private float _timeToFinish;

        [SerializeField]
        private Sprite _levelBackgroundImage;

        [SerializeField]
        private LootBase[] _loots;

        [SerializeField]
        private WeaponModel[] _weapons;

        public string LevelName => _name;

        public float TimeToFinish => _timeToFinish;

        public Sprite LevelBackgroundImage => _levelBackgroundImage;

        public LootBase[] Loots => _loots;

        public WeaponModel[] Weapons => _weapons;
    }
}