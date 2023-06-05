using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TimerView : MonoBehaviour
{
    private TMP_Text _timerText;

    private void Awake()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    public void SetText(float time)
    {
        _timerText.text = time.ToString("0");
    }
}
