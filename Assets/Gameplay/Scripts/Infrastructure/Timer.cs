using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action<float> TimerTick;
    public Action TimerComplete;

    [SerializeField]
    private float _timerToSet;

    [SerializeField]
    private float _timeElapsed;

    [SerializeField]
    private bool _timerOn = false;


    public void SetStartTime(float timeToSet)
    {
        _timerToSet = timeToSet;
    }

    [ContextMenu("Test/Start Timer")]
    public void StartTimer()
    {
        _timeElapsed = _timerToSet;
        _timerOn = true;
    }

    public void StopTimer()
    {
        _timerOn = false;
    }

    void Update()
    {
        if (!_timerOn)
        { 
            return; 
        }

        if (_timeElapsed <= 0)
        {
            TimerComplete?.Invoke();
            return;
        }

        _timeElapsed -= Time.deltaTime;

        TimerTick?.Invoke(_timeElapsed);
    }

    public bool TimeUp => _timerToSet <= 0;
}
