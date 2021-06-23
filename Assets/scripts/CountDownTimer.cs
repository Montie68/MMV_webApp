using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class CountDownTimer : MonoBehaviour
{
    #region Public
    //public members go here
    [System.Serializable]
    public struct Triggers
    {
        public int _tiggerTime;
        public UnityEvent _triggerActions;
    }
    [System.Serializable]
    public struct TimerColors
    {
        public Color32 _timeColor;
        [Range(0,1)]
        public float _timeTriggerPercentage;
    }
    public enum TIMERDIRECTION
    {
        CountDown = -1,
        CountUp = 1,
    }
    #endregion

    #region Private
    //private members go here
    [SerializeField] TIMERDIRECTION _timerDirection = TIMERDIRECTION.CountDown;
    [SerializeField] TextMeshProUGUI _timerDisplay;
    [SerializeField] int _countDownTime = 15;
    [SerializeField] List<Triggers> _triggerList;
    [SerializeField] UnityEngine.UI.Slider _timerSlider;
    [SerializeField] List<TimerColors> _timersColors;
    bool _usingSlider = false;
    
    Material _displayMaterial;

    bool _isRunning = false;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    private void Start()
    {
        _displayMaterial = _timerDisplay.fontMaterial;
        _usingSlider = _timerSlider == null ? false : true;
        _timerSlider.maxValue = _countDownTime;
    }
    private void OnDisable() => _timerDisplay.fontMaterial = _displayMaterial;

    #endregion
    #region Public Methods
    //Place your public methods here
    public void StartCounter(int time = 0)
    {
        if (time != 0) _countDownTime = time;
        _isRunning = true;
        StartCoroutine(StartTimer());
    }

    public void StopCounter() =>_isRunning = false;
    
    #endregion
    #region Private Methods
    //Place your public methods here
    private IEnumerator StartTimer()
    {
        _timerDisplay.text = String.Format("{0}", _countDownTime.ToString("D2"));
        _timerSlider.maxValue = _countDownTime;
        _timerSlider.wholeNumbers = false;
        StartCoroutine(CountDownTimerTick());
        if (_timerDirection == TIMERDIRECTION.CountDown)  _timerSlider.value = _countDownTime;
        do
        {
            yield return new WaitForSeconds(1);

            _countDownTime = _countDownTime + (int)_timerDirection;
            _timerDisplay.text = String.Format("{0}", _countDownTime.ToString("D2"));



            foreach (Triggers t in _triggerList)
            {
                if (t._tiggerTime == _countDownTime)
                    t._triggerActions?.Invoke();
            }
        } while (_isRunning);
    }

    private IEnumerator CountDownTimerTick()
    {

        do
        {
            yield return new WaitForSeconds(1/60);
            float mod = (float)_timerDirection /60;
            _timerSlider.value = _timerSlider.value+mod;
            foreach (TimerColors t in _timersColors)
            {
                if ((_timerSlider.value / _timerSlider.maxValue) <= t._timeTriggerPercentage && _timerSlider.targetGraphic.color != t._timeColor)
                {
                    _timerSlider.targetGraphic.color = (t._timeColor);
                }
            }
        } while (_isRunning);


    }
    #endregion

}
