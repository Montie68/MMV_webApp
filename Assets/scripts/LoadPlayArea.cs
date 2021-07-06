using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPlayArea : MonoBehaviour
{

    #region Private
    //private members go here

    [SerializeField] Transform _playArea;
    [SerializeField] TextMeshProUGUI _levelTitleText;
    [SerializeField] GameObject _objTextPrefab;
    [SerializeField] Transform _objTextArea;
    [SerializeField] GameObject _videoButtonsPrefab;
    [SerializeField] Transform _videoButtonScrollArea;
    [SerializeField] TextMeshProUGUI _levelObjectText;

    #endregion

    #region Public
    //public members go here
    [SerializeField] public CountDownTimer _countDownTimer;

    [HideInInspector] public List<TextMeshProUGUI> objectsToFindText;
    [HideInInspector] public Museum museumScriptable;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 

    #region Unity Messages 
    // Start is called before the first frame update
    // Update is called once per frame

    void OnDisable()
    {
        museumScriptable = null;
        Transform[] objs = _playArea.GetComponentsInChildren<Transform>();
        foreach (Transform t in objs)
        {
            if (t != _playArea.transform) 
                Destroy(t.gameObject);
        }

        TextMeshProUGUI[] objTexts = _objTextArea.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI t in objTexts)
        {
            if (t.transform != _objTextArea.transform)
                Destroy(t.gameObject);
        }
        Button[] videoButtons = _videoButtonScrollArea.GetComponentsInChildren<Button>();
        foreach (Button b in videoButtons)
        {
            if (b.transform != _videoButtonScrollArea.transform)
                Destroy(b.gameObject);
        }
        _levelTitleText.text = "";
        _levelTitleText.color = new Color32(225, 255, 255, 0);


    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void LoadPlayLevel(Museum _museum)
    {
        museumScriptable = _museum;
        _levelTitleText.text = _museum.titleText;
        _levelTitleText.color = new Color32(225, 255, 255, 255);
        _countDownTimer.StartCounter(_museum.secondsToFindObjs);
        int counter = 1;
        // clean out text area
        TextMeshProUGUI[] textArea = _objTextArea.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI t in textArea)
        {
            Destroy(t.gameObject);
        }

        foreach (Museum.PlayObjects g in _museum.objectsToFind)
        {
            GameObject obj = GameObject.Find(g.name);
            if (obj != null) Destroy(obj);


            obj = Instantiate(g.gameObj, _playArea,false);
            obj.name = g.name;


            GameObject objText = Instantiate(_objTextPrefab, _objTextArea, false);
            objText.name = g.name;
            TextMeshProUGUI t = objText.GetComponent<TextMeshProUGUI>();
            t.text = counter++ +". " + g.name;
        }
        foreach (Museum.Videos v in _museum.VideoClipNames)
        {
            GameObject obj = GameObject.Find(v.VideoClipNames);
            if (obj != null) Destroy(obj);

            GameObject objBtn = Instantiate(_videoButtonsPrefab, _videoButtonScrollArea, false);
            objBtn.name = v.VideoClipNames;
            TextMeshProUGUI t = objBtn.GetComponentInChildren<TextMeshProUGUI>();
            t.text =  v.VideoClipNames;
            LoadVideo lv = objBtn.GetComponent<LoadVideo>();
            if (lv != null) lv.videoUrl = v.VideoClipUrls;
            else Debug.LogError("No LoadVideo Component Found");
        }
        int i = 1;

        foreach (Museum.PlayObjects po in _museum.objectsToFind)
        {
            _levelObjectText.text += i++ + ".    <b>" + po.name + "</b><br> \n\r";
            _levelObjectText.text += po.description + "<br><br> \n\r\n\r";
        }

    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
