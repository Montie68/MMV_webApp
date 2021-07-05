using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class SwoopMenuEditor : Editor
{
    #region Public
    //public members go here
    #endregion

    #region Private
    //private members go here
    SerializedProperty _newPos;
    swooshMenu swooshMenu;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Public Methods
    //Place your public methods here
    #endregion
    #region Private Methods
    //Place your public methods here
    private void OnEnable()
    {
        _newPos = serializedObject.FindProperty("_newPos");
    }
    #endregion

}
