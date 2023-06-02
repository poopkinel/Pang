using Gameplay.Models;
using General.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Models
{
    public interface ILoot
    {
        public void ApplyEffect(LevelModel levelModel, PlayerModel playerModel);
    }
}