using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonOuterGlow : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler 
{

    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    [SerializeField] Image _buttonImage;
    [SerializeField] Material _buttonMaterial;
    bool isClicked = false;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 

    #endregion
    #region Public Methods
    //Place your public methods here
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_buttonImage.material == null) _buttonImage.material = _buttonMaterial;
        isClicked = isClicked ? false : true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_buttonImage.material.name == "Default UI Material") 
            _buttonImage.material = _buttonMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_buttonImage.material != null && !isClicked) 
            _buttonImage.material = null;
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
