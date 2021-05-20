using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerScript : EventActions
{
    #region Public
    //public members go here
    #endregion

    #region Private
    //private members go here
    [SerializeField] float _tiggerDelay = 0.0f;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    void Start()
    {
    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            RunAction(_tiggerDelay);
        }
    }
    #endregion
    #region Public Methods
    //Place your public methods here

    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
