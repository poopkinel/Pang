using Cysharp.Threading.Tasks;
using Gameplay.Models;
using General.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevelFlow : IFlow
{
    private GameModel _gameModel;

    private List<PlayerModel> _players;

    public EnterLevelFlow(GameModel gameModel, List<PlayerModel> players)
    {
        _gameModel = gameModel;
        _players = players;
    }

    public void Execute()
    {
        SceneManager.LoadScene(SystemSceneIndexes.GAMEPLAY);
        _gameModel.SetPlayers(_players);
        SceneManager.UnloadSceneAsync(SystemSceneIndexes.MULTIPLAYER);
    }
}
