using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public void IsClicked(bool click)
        {
            isClicked = click;
        }
    }


    List<ObjButtons> _levelObjectButtons = new List<ObjButtons>();
    LoadPlayArea _playArea;
    Museum _museumScriptable;

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
        StartCoroutine(GetCurrnetLevel());
    }


    void OnDisable()
    {
        _museumScriptable = null;
        _levelObjectButtons = new List<ObjButtons>();
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void AddObjectButtone(LevelObjectButton objectButton)
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
       
    }

    #endregion

}
