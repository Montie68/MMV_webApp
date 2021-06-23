using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventActions : MonoBehaviour
{
    #region Public
    //public members go here
    public UnityEvent _actionsToRun;
    #endregion

    #region Private
    //private members go here
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public virtual void RunAction(float delay) => StartCoroutine(ActionCoroutine(delay));
    
    public virtual IEnumerator ActionCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        _actionsToRun?.Invoke();
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
