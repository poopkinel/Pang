using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TimerView : MonoBehaviour
{
    #region Private Fields

    private TMP_Text _timerText;

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    #endregion

    #region Methods 

    public void SetText(float time)
    {
        _timerText.text = time.ToString("0");
    }

    #endregion
}
