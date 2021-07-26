using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(LoadPlayArea))]
public class LevelManger : MonoBehaviour
{
    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    class ObjButtons
    {
        public LevelObjectButton levelObjectButton { get; private set; }
        public bool isClicked { get; private set; }

        public ObjButtons(LevelObjectButton btn, bool isClick = false)
        {
            levelObjectButton = btn;
            isClicked = isClick;
        }
        public void IsClicked(bool click) =>  isClicked = click;
    }


    List<ObjButtons> _levelObjectButtons = new List<ObjButtons>();
    LoadPlayArea _playArea;
    Museum _museumScriptable;
    [SerializeField] LoadALevel _tryAgainButton;
    [SerializeField] UnityEvent _completeActions;
    [SerializeField] UnityEvent _failActions;
    [SerializeField] UnityEvent _ResetEvents;


    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void Start()
    {
        _playArea = GetComponent<LoadPlayArea>();
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        CountDownTimer.timerEnded += TimerEnded;
        HighlightIcons.hideForSec += HideObjectForSec;
        StartCoroutine(GetCurrnetLevel());
        StartCoroutine(RunLevel());
    }


    void OnDisable()
    {
        _museumScriptable = null;
        _levelObjectButtons = new List<ObjButtons>();
        _ResetEvents?.Invoke();
        CountDownTimer.timerEnded -= TimerEnded;
        HighlightIcons.hideForSec -= HideObjectForSec;
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void Reload()
    {
       _tryAgainButton.museum = _museumScriptable;
    }
    public void ReloadLevel()
    {
        GetComponent<LoadPlayArea>().DeleteVideoButtons();
        _levelObjectButtons = new List<ObjButtons>();
        StartCoroutine(RunLevel());
    }
    public void AddObjectButton(LevelObjectButton objectButton)
    {
        _levelObjectButtons.Add(new ObjButtons(objectButton));
    }
    public void ObjectFound(LevelObjectButton objectButton)
    {
        foreach (ObjButtons o in _levelObjectButtons)
        {
            if (o.levelObjectButton == objectButton)
            {
                o.IsClicked(o.isClicked != true ? true : false);
                
                TextMeshProUGUI text = null;

                foreach (Museum.PlayObjects g in _museumScriptable.objectsToFind)
                {
                    TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();
                    foreach (TextMeshProUGUI t in texts)
                    {
                        if (t.name == o.levelObjectButton.name)
                        {
                            text = t;
                        }
                    }

                }

                if (o.isClicked)
                {
                    text.text +=  "<sprite=32>";
                }
                else
                {
                    text.text = text.text.Remove(text.text.IndexOf("<sprite=32>"));
                }
                break;
            }
        }
    }

    #endregion
    #region Private Methods
    //Place your public methods here
    private IEnumerator GetCurrnetLevel()
    {
        bool isNull = true;
        while (isNull)
        {
            yield return new WaitForSeconds(1 / 30);
            if (_playArea.museumScriptable != null) isNull = false;
        }
        
        _museumScriptable = _playArea.museumScriptable;
        Reload();
    }

    private IEnumerator RunLevel()
    {
        bool isRunning = true;
        while (isRunning)
        {
            LOOP_RESTART:
            yield return new WaitForSeconds(1 / 30);
            foreach (ObjButtons o in _levelObjectButtons)
            {
                if (!o.isClicked)
                    goto LOOP_RESTART;
            }
            isRunning = false;

        }
        Debug.Log("All Clicked");
        _completeActions?.Invoke();
    }
    private void TimerEnded()
    {
        foreach (ObjButtons o in _levelObjectButtons)
        {
            o.levelObjectButton.thisButton.interactable = false;
        }
        _failActions?.Invoke();
    }

    private void HideObjectForSec(GameObject obj, float timer)
    {
        StartCoroutine(HideForSec(obj, timer));
    }
    IEnumerator HideForSec(GameObject o, float timer)
    {
        o.SetActive(false);
        yield return new WaitForSeconds(timer);
        o.SetActive(true);
    }
    #endregion

}
