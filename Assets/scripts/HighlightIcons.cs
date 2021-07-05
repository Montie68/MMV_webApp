using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightIcons : MonoBehaviour
{
    #region Public
    //public members go here
    public delegate void HideForSeconds(GameObject obj, float timer);
    public static event HideForSeconds hideForSec;

    #endregion

    #region Private
    //private members go here
    [SerializeField] string _tag;
    [SerializeField] float _hideForSeconds = 3f;
    
    List<Image> _iconImages = new List<Image>();

    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void OnEnable()
    {

    }

    // Update is called once per frame
    void OnDisable()
    {
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void HighlightTheIcons()
    {
        Image[] objs = FindObjectsOfType<Image>();
        foreach (Image i in objs)
        {
            if (i.gameObject.tag == _tag)
                _iconImages.Add(i);
        }

        foreach (Image i in _iconImages)
        {
            Color c = i.color;
            i.color = new Color(c.r, c.g, c.b, 1.0f);
        }
        _iconImages = new List<Image>();
    }

    public void HideMenu(GameObject obj)
    {
        hideForSec?.Invoke(obj, _hideForSeconds);
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
