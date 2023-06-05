using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenMenu : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private Button _restartBtn;

    #endregion

    #region Unity callbacks

    private void Awake()
    {
        _restartBtn.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _restartBtn.onClick.RemoveAllListeners();
    }

    #endregion

    #region Methods

    private void OnClick()
    {
        new GameOverToStartScreenFlow().Execute();
    }

    #endregion
}
