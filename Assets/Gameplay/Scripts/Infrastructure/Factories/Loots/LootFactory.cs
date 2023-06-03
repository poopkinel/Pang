using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Infrastructure.Factories
{
    public abstract class LootFactory : MonoBehaviour
    {
        #region Methods

        public abstract ILoot Create(Vector2 position);

        #endregion
    }

}