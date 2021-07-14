using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadSubMenu : MonoBehaviour
{

    #region Private
    //private members go here

    [SerializeField] TextMeshProUGUI _levelTitleText;
    [SerializeField] TextMeshProUGUI _levelObjectText;
    [SerializeField] TextMeshProUGUI _playButtonText;
    [SerializeField] TextMeshProUGUI _levelTimerWarningText;
    [SerializeField] LoadALevel _levelLoadButton;
    [SerializeField] GameObject _videoButtonsPrefab;
    [SerializeField] Transform _videoButtonScrollArea;
    [SerializeField] List<Button> _menuButtons;
    [SerializeField] UnityEngine.Events.UnityEvent ResetEvents;
    static string _sTitle;
        
    #endregion

    #region Public
    //public members go here
    [HideInInspector] public Museum _museumScriptable;


    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 

    #region Unity Messages 
    // Start is called before the first frame update
    // Update is called once per frame

    void OnDisable()
    {
        _levelObjectText.text = _levelTitleText.text = "";
        Button[] videoButtons = _videoButtonScrollArea.GetComponentsInChildren<Button>();
        foreach (Button b in videoButtons)
        {
            if (b.transform != _videoButtonScrollArea.transform)
                Destroy(b.gameObject);
        }
    }
    
    #endregion
    #region Public Methods
    //Place your public methods here
    public void LoadPlayLevel(Museum _museum)
    {
        _museumScriptable = _museum;
        _levelTitleText.text = _museum.titleText;
        string[] s = _museum.titleText.Split(' ');
        if (_playButtonText.text.Contains("[title]")) _playButtonText.text = _playButtonText.text.Replace("[title]", s[0]);
        else _playButtonText.text = _playButtonText.text.Replace(_sTitle, s[0]);
        _sTitle = s[0];
        _levelTimerWarningText.text = _levelTimerWarningText.text.Replace("[x]", _museum.secondsToFindObjs.ToString());
        _levelLoadButton.museum = _museum;
        int i = 1;
        foreach (Museum.PlayObjects po in _museum.objectsToFind)
        {
            _levelObjectText.text += i++ + ".    <b>" + po.name + "</b><br> \n\r";
            _levelObjectText.text += po.description + "<br><br> \n\r\n\r";
        }
        foreach (Button b in _menuButtons)
        {
            TextMeshProUGUI t = b.GetComponentInChildren<TextMeshProUGUI>();
            b.gameObject.SetActive(t.text == _museum.titleText ? false : true);
        }

        foreach (Museum.Videos v in _museum.VideoClipNames)
        {
            GameObject obj = GameObject.Find(v.VideoClipNames);
            if (obj != null) Destroy(obj);

            GameObject objBtn = Instantiate(_videoButtonsPrefab, _videoButtonScrollArea, false);
            objBtn.name = v.VideoClipNames;
            TextMeshProUGUI t = objBtn.GetComponentInChildren<TextMeshProUGUI>();
            t.text = v.VideoClipNames;
            LoadVideo lv = objBtn.GetComponent<LoadVideo>();
            if (lv != null) lv.videoUrl = v.VideoClipUrls;
            else Debug.LogError("No LoadVideo Component Found");
        }
    }

    public void Reset()
    {
        ResetEvents?.Invoke();
    }
    
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion
}
