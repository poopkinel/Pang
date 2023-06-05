using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayToGameOverScreenFlow : IFlow
{
    private LevelModel _level;

    public GameplayToGameOverScreenFlow(LevelModel level)
    {
        _level = level;
    }

    public void Execute()
    {
        SceneManager.LoadScene(SystemSceneIndexes.GAME_OVER_SCREEN);
        SceneManager.UnloadSceneAsync(_level.SceneIndex);
    }
}
