using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverToStartScreenFlow : IFlow
{
    public void Execute()
    {
        SceneManager.LoadScene(SystemSceneIndexes.START_SCREEN);
        SceneManager.UnloadSceneAsync(SystemSceneIndexes.GAME_OVER_SCREEN);
    }
}
