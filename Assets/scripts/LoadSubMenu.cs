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
    [SerializeField] TextMeshProUGUI _levelObjectText;
    [SerializeField] TextMeshProUGUI _playButtonText;
    #endregion

    #region Public
    //public members go here
    [HideInInspector] public Museum _museumScriptable;

    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 

    #region Unity Messages 
    // Start is called before the first frame update
    // Update is called once per frame

    void OnDisable() => _levelObjectText.text = _levelTitleText.text = "";
    
    #endregion
    #region Public Methods
    //Place your public methods here
    public void LoadPlayLevel(Museum _museum)
    {
        _museumScriptable = _museum;
        _levelTitleText.text = _museum.titleText;
        string[] s = _museum.titleText.Split(' ');
        _playButtonText.text = _playButtonText.text.Replace("[title]", s[0]);
        int i = 1;
        foreach (Museum.PlayObjects po in _museum.objectsToFind)
        {
            _levelObjectText.text += i++ + ".    <b>" + po.name + "</b><br> \n\r";
            _levelObjectText.text += po.description + "<br><br> \n\r\n\r";
        }
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion
}
