using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float _timerToSet;

    [SerializeField]
    private float _timeElapsed;

    [SerializeField]
    private bool _timerOn = false;

    public void SetTime(float timeToSet)
    {
        _timerToSet = timeToSet;
    }

    public void SetTimerOn(bool activate)
    {
        _timerOn = activate;
    }

    void Update()
    {
        if (!_timerOn)
        { 
            return; 
        }

        if (_timeElapsed <= 0)
        {
            return;
        }

        _timeElapsed -= Time.deltaTime;

    }

    public bool TimeUp => _timerToSet <= 0;
}
