using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Infrastructure
{
    [System.Serializable]
    struct PlayerButtonTriplet
    {
        public InputButton right;
        public InputButton left;
        public InputButton fire;
    }

    public class MobileInputManager : InputManager
    {
        #region Editor

        [SerializeField]
        private List<PlayerButtonTriplet> _playersButtons;

        [SerializeField]
        private List<PlayerView> _players = new List<PlayerView>();

        #endregion

        #region Unity Callbacks

        private void Update()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_playersButtons[i].left.Pressed)
                {
                    _players[i].MoveHorizontal(-1f);
                }
                if (_playersButtons[i].right.Pressed)
                {
                    _players[i].MoveHorizontal(1f);
                }
                if (_playersButtons[i].fire.Pressed)
                {
                    _players[i].Fire();
                }
            }
        }

        #endregion

        #region Methods

        public override void SetPlayers(List<PlayerView> playerViews)
        {
            _players = playerViews;
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
    }
}