using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadALevel : MonoBehaviour
{


    #region Private
    //private members go here
    [SerializeField] LoadPlayArea _levelToLoad;
    [SerializeField] GameObject _menuToHide;
    private Button _aButton;
    #endregion
    #region Public
    //public members go here
    [SerializeField] public Museum museum;

    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            _aButton = GetComponent<Button>();
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            return;
        }


        _aButton.onClick.AddListener(LoadLevel);
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
    private void  LoadLevel()
    {
        if (!_levelToLoad.gameObject.activeInHierarchy) _levelToLoad.gameObject.SetActive(true);
        else
        {

        }
        _menuToHide.SetActive(false);
        _levelToLoad.LoadPlayLevel(museum);
    }
    #endregion

}
