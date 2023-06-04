using Gameplay.Models;
using General.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNextLevelFlow : IFlow
{
    private GameModel _gameModel;
    
    private LevelModel _currentLevelModel;

    public EnterNextLevelFlow(GameModel gameModel, LevelModel currentLevelModel)
    {
        _gameModel = gameModel;
        _currentLevelModel = currentLevelModel;
    }

    public void Execute()
    {
        var indexOfCurrentLevel = _gameModel.Levels.ToList().IndexOf(_currentLevelModel);
        if (indexOfCurrentLevel + 1 < _gameModel.Levels.Length)
        {
            var nextLevel = _gameModel.Levels[indexOfCurrentLevel + 1];
            SceneManager.LoadScene(nextLevel.SceneIndex);
        }
    }
}
