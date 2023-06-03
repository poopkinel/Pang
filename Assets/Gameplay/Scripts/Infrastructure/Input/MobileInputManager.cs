using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Infrastructure.Input
{
    [System.Serializable]
    public struct PlayerButtonTriplet
    {
        public InputButton right;
        public InputButton left;
        public InputButton fire;
    }


    public class MobileInputManager : InputManager
    {
        #region Editor

        [SerializeField]
        private PlayerButtonTriplet _players1Inputs;

        [SerializeField]
        private PlayerButtonTriplet _players2Inputs;

        [SerializeField]
        private PlayerView _player1;

        [SerializeField]
        private PlayerView _player2;

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            // Player 1
            if (_players1Inputs.left.IsPressed)
            {
                _player1.MoveHorizontal(-1f);
            }

            //if (_players1Inputs.right.IsPressed)
            //{
            //    _player1.MoveHorizontal(1f);
            //}

            //if (_players1Inputs.fire.IsPressed)
            //{
            //    _player1.Fire();
            //}


            //// Player 2
            //if (_players2Inputs.left.IsPressed)
            //{
            //    _player2.MoveHorizontal(-1f);
            //}

            //if (_players2Inputs.right.IsPressed)
            //{
            //    _player2.MoveHorizontal(1f);
            //}

            //if (_players2Inputs.fire.IsPressed)
            //{
            //    _player2.Fire();
            //}
        }

        #endregion

        #region Methods

        public override void SetPlayers(PlayerView player1, PlayerView player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public override void Move(PlayerView player, float horizontalAxis)
        {
            player.MoveHorizontal(horizontalAxis);
        }
        public override void Fire(PlayerView player)
        {
            player.Fire();
        }

        #endregion

        #region Properties

        public PlayerView Player1 => _player1;

        public PlayerView Player2 => _player2;

        #endregion
    }
}