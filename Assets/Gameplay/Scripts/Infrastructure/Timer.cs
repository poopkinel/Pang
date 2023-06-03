using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Events

    public Action<float> TimerTick;
    public Action TimerComplete;

    #endregion

    #region Editor

    [SerializeField]
    private float _timerToSet;

    [SerializeField]
    private float _timeElapsed;

    [SerializeField]
    private bool _timerOn = false;

    #endregion

    #region Methods

    public void SetStartTime(float timeToSet)
    {
        _timerToSet = timeToSet;
    }

    public void AddTime(float timeToAdd)
    {
        _timeElapsed += timeToAdd;
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

    #endregion

    #region Unity Callbacks

    void Update()
    {
        if (!_timerOn)
        { 
            return; 
        }

        if (_timeElapsed <= 0)
        {
            TimerComplete?.Invoke();
            StopTimer();
            return;
        }

        _timeElapsed -= Time.deltaTime;

        TimerTick?.Invoke(_timeElapsed);
    }

    #endregion

    #region Properties

    public float TimeElapsed => _timeElapsed;

    public bool TimeUp => _timerToSet <= 0;

    #endregion
}
