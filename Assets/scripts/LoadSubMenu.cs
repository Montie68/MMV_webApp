using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadSubMenu : MonoBehaviour
{

    #region Private
    //private members go here

    [SerializeField] TextMeshProUGUI _levelTitleText;
    private Museum _museumScriptable;
    #endregion

    #region Public
    //public members go here

    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 

    #region Unity Messages 
    // Start is called before the first frame update
    // Update is called once per frame

    void OnDisable() => _levelTitleText.text = "";
    
    #endregion
    #region Public Methods
    //Place your public methods here
    public void LoadPlayLevel(Museum _museum)
    {
        _museumScriptable = _museum;
        _levelTitleText.text = _museum.titleText;
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
