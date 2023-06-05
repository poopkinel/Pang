using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenMenu : MonoBehaviour
{
    [SerializeField]
    private Button _restartBtn;

    private void Awake()
    {
        _restartBtn.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _restartBtn.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        new GameOverToStartScreenFlow().Execute();
    }
}
