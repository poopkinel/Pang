using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Infrastructure.Input
{
    public abstract class InputManager : MonoBehaviour
    {
        public abstract void SetPlayers(PlayerView player1, PlayerView player2);
        public abstract void Move(PlayerView player, float horizontalAxis);
        public abstract void Fire(PlayerView player);
    }
}