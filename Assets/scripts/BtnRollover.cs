using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnRollover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    [SerializeField] Image _imageComponent;
    [SerializeField] Sprite _normalImage;
    [SerializeField] Sprite _swapImage;
    Button _thisButton;
  #endregion
  // Place all unity Message Methods here like OnCollision, Update, Start ect. 
  #region Unity Messages 
    void Start()
    {
        try
        {
            _thisButton = GetComponent<Button>();
        } catch(System.Exception e)
        {
            Debug.LogErrorFormat("No Button attached to Game Object: {0}", e);
            return;
        }
        
    }
	
    void OnDisable()
    {
        if (_imageComponent.sprite == _swapImage)
            SwapImage();
    }
    #endregion
    #region Public Methods
    //Place your public methods here

    #endregion
    #region Private Methods
    //Place your public methods here
    private void SwapImage()
    {
        Sprite sprite = _imageComponent.sprite != _normalImage ? _normalImage : _swapImage;
        
        _imageComponent.sprite = sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SwapImage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SwapImage();
    }
    #endregion

}
