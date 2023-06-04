using Gameplay.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromGameplayToStartScreenFlow : IFlow
{
    private LevelModel _currentLevel;

    public FromGameplayToStartScreenFlow(LevelModel currentLevel)
    {
        _currentLevel = currentLevel;
    }

    public void Execute()
    {
        SceneManager.LoadScene(SystemSceneIndexes.START_SCREEN);
        SceneManager.UnloadSceneAsync(_currentLevel.SceneIndex);
    }
}
