using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Models
{
    [CreateAssetMenu(menuName = "Pang Models/Balls Model", fileName = "Balls Model")]
    public class BallsModel : ScriptableObject
    {
        [SerializeField]
        private List<Ball> balls = new List<Ball>();
    }
}