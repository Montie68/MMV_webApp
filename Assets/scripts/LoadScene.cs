using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    [SerializeField] string _sceneName = "<none>";
    [SerializeField] int _sceneNumber = -1;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void LoadAScene()
    {
        if (_sceneName == "<none>" || _sceneName == "")
        {
            if (_sceneNumber > 0) SceneManager.LoadScene(_sceneNumber);
            else goto END;
        }
        else SceneManager.LoadScene(_sceneName);
        
        END:       
        return;
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
