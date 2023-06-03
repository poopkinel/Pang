using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Models
{
    [CreateAssetMenu(menuName = "Pang Models/Weapon Model", fileName = "Weapon Model")]
    public class WeaponModel : ScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;

        [SerializeField]
        private string _name;

        [SerializeField]
        private float _projectileSpeed;

        public GameObject Prefab => _prefab;

        public string Name => _name;

        public float ProjectileSpeed => _projectileSpeed;
    }
}