using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterMultplayerScreen : IFlow
{
    public void Execute()
    {
        SceneManager.LoadScene(SystemSceneIndexes.MULTIPLAYER);
        SceneManager.UnloadSceneAsync(SystemSceneIndexes.START_SCREEN);
    }
}
