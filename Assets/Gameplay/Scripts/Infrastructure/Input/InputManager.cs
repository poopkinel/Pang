using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Infrastructure
{
    public abstract class InputManager : MonoBehaviour
    {
        public abstract void SetPlayers(List<PlayerView> playerViews);
        public abstract void Move(PlayerView player, float horizontalAxis);
        public abstract void Fire(PlayerView player);
    }
}