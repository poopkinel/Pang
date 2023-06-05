using Gameplay.Controllers;
using Gameplay.Enums;
using Gameplay.Models;
using General.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Models
{
    public interface ILoot
    {
        public void ApplyEffect(LevelController levelModel, PlayerController playerModel);

        public LootType LootType { get; }
    }
}