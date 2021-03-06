using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DoorTrigger : MonoBehaviour
{
    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    [SerializeField] string _forwardAnimation;
    [SerializeField] string _backAnimation;
    [SerializeField] UnityEvent _TriggerEvents;
    Animator _anim;
    int _animationDirection = 1;
    bool _isAnimPlaying = false;
  #endregion
  // Place all unity Message Methods here like OnCollision, Update, Start ect. 
  #region Unity Messages 
    void Start() => _anim = GetComponent<Animator>();
  
	
    void Update()
    {
		
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void OpenDoor()
    {
        if (_isAnimPlaying) 
            return;

        if (_animationDirection == 1)
            _anim.Play(_forwardAnimation);
        else if (_backAnimation != "")
            _anim.Play(_backAnimation);

        _animationDirection *= -1;
    }
    public void RunAnime()
    {
        _isAnimPlaying = _isAnimPlaying ? false : true;

        if (_isAnimPlaying)
            _TriggerEvents?.Invoke();
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
