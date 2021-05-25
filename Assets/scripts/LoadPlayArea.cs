using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPlayArea : MonoBehaviour
{
    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    [SerializeField] Transform _playArea;
    [SerializeField] TextMeshProUGUI _levelTitleText;
    [SerializeField] CountDownTimer _countDownTimer;
    #region Unity Messages 
    // Start is called before the first frame update
    // Update is called once per frame

    void OnDisable()
    {
        Transform[] objs = _playArea.GetComponentsInChildren<Transform>();
        foreach (Transform t in objs)
        {
            if (t != _playArea.transform) 
                Destroy(t.gameObject);
        }
        _levelTitleText.text = "";
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void LoadPlayLevel(Museum _museum)
    {
        _levelTitleText.text = _museum.titleText;
        _countDownTimer.StartCounter(_museum.secondsToFindObjs);
        foreach (Museum.PlayObjects g in _museum.objectsToFind)
        {
            GameObject obj = Instantiate(g.gameObj, _playArea,false);
            

        }
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
