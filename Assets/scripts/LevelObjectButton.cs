using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectButton : MonoBehaviour
{
    #region Public
    //public members go here
    [HideInInspector] public UnityEngine.UI.Button thisButton;

    #endregion

    #region Private
    //private members go here
    [SerializeField] LevelManger _levelManger;
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
                    _levelManger.AddObjectButton(this);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }
        thisButton = GetComponent<UnityEngine.UI.Button>();
        thisButton.onClick.AddListener(delegate() {
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
