using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BtnClickFontSwap : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler

{
    #region Public
    //public members go here

    #endregion

    #region Private
    //private members go here
    [SerializeField] TMP_FontAsset _clickedFont;
    [SerializeField] Color32[] _clickedColor;
    Color32 _baseColor;
    TMP_FontAsset _baseFont;
    TextMeshProUGUI _buttonText;
    Button _thisButton;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void Start()
    {
        try 
        {
            _buttonText = GetComponentInChildren<TextMeshProUGUI>(); 
        }
        catch (System.Exception e) 
        { 
            Debug.LogException(e); 
        }

        try { _thisButton = GetComponentInChildren<Button>(); }
        catch (System.Exception e) { Debug.LogException(e); }

        _thisButton.onClick.AddListener(ChangeFont);
        _baseFont = _buttonText.font;
        _baseColor = _buttonText.color;

    }


    private void OnDisable()
    {
       if (_baseFont != null) _buttonText.font = _baseFont;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void OnPointerDown(PointerEventData eventData) => ChangeFont();

    
    #endregion
    #region Private Methods
    //Place your public methods here
    private void ChangeFont()
    {
        if (_clickedFont != null)
        {
            _buttonText.font = _clickedFont;
            _buttonText.fontSize = 32;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_clickedColor.Length != 0)
            _buttonText.color = _clickedColor[0];
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_clickedColor.Length != 0)
            _buttonText.color = _baseColor;
    }
    public void OnPointerClick(PointerEventData eventData) => OnPointerExit(eventData);
    


    #endregion

}
