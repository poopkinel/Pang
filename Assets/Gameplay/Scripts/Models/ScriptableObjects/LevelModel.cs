using Gameplay.Enums;
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
        private LevelTargetsModel _levelTargetsModel;

        [SerializeField]
        private float _timeToFinish;

        [SerializeField]
        private Sprite _levelBackgroundImage;

        [SerializeField]
        private LootType[] _levelLoots;

        [SerializeField]
        private WeaponModel[] _levelWeapons;

        [SerializeField]
        private int _pointsForEachBallHit;

        [SerializeField]
        private int _sceneIndex;

        public string LevelName => _name;

        public LevelTargetsModel ThisLevelTargetsModel => _levelTargetsModel;

        public float TimeToFinish => _timeToFinish;

        public Sprite LevelBackgroundImage => _levelBackgroundImage;

        public LootType[] Loots => _levelLoots;

        public WeaponModel[] Weapons => _levelWeapons;

        public int PointsForEachBallHit => _pointsForEachBallHit;

        public int SceneIndex => _sceneIndex;
    }
}