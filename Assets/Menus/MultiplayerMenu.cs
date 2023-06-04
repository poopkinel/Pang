using Gameplay.Models;
using General.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerMenu : MonoBehaviour
{
    [SerializeField]
    private List<PlayerModel> _players;

    [SerializeField]
    private GameModel _gameModel;

    [SerializeField]
    private Button _singlePlayerButton;

    [SerializeField]
    private Button _multiplayerButton;

    private void Awake()
    {
        _singlePlayerButton.onClick.AddListener(SinglePlayerClicked);
        _multiplayerButton.onClick.AddListener(MultiplayerClicked);
    }

    private void OnDestroy()
    {
        _singlePlayerButton.onClick.RemoveAllListeners();
        _multiplayerButton.onClick.RemoveAllListeners();
    }

    private void MultiplayerClicked()
    {
        var flow = new EnterLevelFlow(_gameModel, _players);
        flow.Execute();
    }

    private void SinglePlayerClicked()
    {
        var flow = new EnterLevelFlow(_gameModel, new List<PlayerModel>() { _players[0] });
        flow.Execute();
    }

}
