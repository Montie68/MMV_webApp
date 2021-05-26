using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectButton : MonoBehaviour
{
    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    [SerializeField] LevelManger _levelManger;
    UnityEngine.UI.Button _thisButton;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void Start()
    {
        if (_levelManger == null)
        {
            try
            {
                if (FindObjectOfType<LevelManger>() == null)
                    throw new NullReferenceException("No LevelManger Component Foun in the Scene!!!");
                else
                {
                    _levelManger = FindObjectOfType<LevelManger>();
                    _levelManger.AddObjectButtone(this);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }
        _thisButton = GetComponent<UnityEngine.UI.Button>();
        _thisButton.onClick.AddListener(delegate() {
            _levelManger.ObjectFound(this);
        });
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
