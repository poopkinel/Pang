using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenMenu : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    private void Awake()
    {
        _startButton.onClick.AddListener(OnStartClicked);
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveAllListeners();
    }

    private void OnStartClicked()
    {
        var flow = new EnterMultplayerScreen();
        flow.Execute();
    }
}
