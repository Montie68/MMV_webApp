using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    [SerializeField] float _speed = 3.0f;
    Vector3 _beginingPos;
    bool _isMoving = false;
    float _distance;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void Start() =>_beginingPos = transform.position;
    

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _beginingPos) > _distance)
            {
                _isMoving = false;
                _beginingPos = transform.position;
            }
        }
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void MoveTheCamera(float distance)
    {
        _distance = distance;
        _isMoving = true;
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
