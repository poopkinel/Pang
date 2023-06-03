using Gameplay.Controllers;
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
        private PlayerController _player1;

        [SerializeField]
        private PlayerController _player2;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            _players1Inputs.fire.ThisButton.onClick.AddListener(_player1.Fire);
        }

        private void OnDestroy()
        {
            _players1Inputs.fire.ThisButton.onClick.RemoveAllListeners();
        }

        private void Update()
        {
            // Player 1
            if (_players1Inputs.left.IsPressed)
            {
                _player1.Move(-1f);
            }

            if (_players1Inputs.right.IsPressed)
            {
                _player1.Move(1f);
            }


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

        public override void SetPlayers(PlayerController player1, PlayerController player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public override void Move(PlayerController player, float horizontalAxis)
        {
            player.Move(horizontalAxis);
        }
        public override void Fire(PlayerController player)
        {
            player.Fire();
        }

        #endregion

        #region Properties

        public PlayerController Player1 => _player1;

        public PlayerController Player2 => _player2;

        #endregion
    }
}