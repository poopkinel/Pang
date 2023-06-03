using Gameplay.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Infrastructure.Input
{
    public abstract class InputManager : MonoBehaviour
    {
        public abstract void SetPlayers(PlayerController player1, PlayerController player2);
        public abstract void Move(PlayerController player, float horizontalAxis);
        public abstract void Fire(PlayerController player);
    }
}