﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ClassContainer;

[CreateAssetMenu(fileName ="MuseumScriptableObject", menuName = "ScriptableObjects/MuseumScriptableObject")]
public class Museum : ScriptableObject
{
    #region Public
    //public members go here
    [System.Serializable]
    public struct PlayObjects
    {
        public string name;
        public GameObject gameObj;
    }
    public LEVELNAMES museumName;
    [Tooltip("The Title for the Level")]
    public string titleText;
    public List<PlayObjects> objectsToFind;
    public int secondsToFindObjs = 10;
    #endregion

    #region Private
    //private members go here
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Public Methods
    //Place your public methods here
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}