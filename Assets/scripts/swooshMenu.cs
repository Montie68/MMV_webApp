using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class swooshMenu : MonoBehaviour, IPointerExitHandler
{
    #region Public
    //public members go here
    [System.Serializable]
    public struct tfElements
    {
        public float top;
        public float bottom;
        public float left;
        public float right;
        public tfElements(float t, float b, float l, float r){ top = t; bottom = b; left = l; right = r;}

    }

    [SerializeField] public tfElements _newPos;
    [SerializeField] public float _transitionTime = 1f;

    #endregion

    #region Private
    //private members go here
    RectTransform _objectsTransform;
    tfElements _startLeftRight;

    bool _isMenuVisable = false;
    [HideInInspector] public bool _isClosing = false;
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void Start()
    {
        try {
            _objectsTransform = GetComponent<RectTransform>();
        }catch
        {
            Debug.LogError("No RectTransform Found on GameObject");
        }
        _startLeftRight = new tfElements(_objectsTransform.offsetMin.y, _objectsTransform.offsetMax.y,
                                         _objectsTransform.offsetMin.x, _objectsTransform.offsetMax.x);
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void OpenCloseMenu() =>  StartCoroutine(AnimateSwoosh());
    public void Closing(bool isClosing) => _isClosing = isClosing;
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_isClosing && _isMenuVisable)
        {
            OpenCloseMenu();
            _isClosing = true;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isMenuVisable) return;
    }
    #endregion
    #region Private Methods
    //Place your public methods here
    private IEnumerator AnimateSwoosh()
    {
        int ticks = 60;
        int ticksDone = 1;
        do
        {
            float daTime = _isMenuVisable != true ? 1 * ((float)ticksDone/(float)ticks)
                : 1 - ((float)ticksDone / (float)ticks);

            _objectsTransform.offsetMin = new Vector2(Mathf.Lerp(_startLeftRight.left, _newPos.left, daTime), 
                Mathf.Lerp(_startLeftRight.bottom, _newPos.bottom, daTime));
            _objectsTransform.offsetMax = new Vector2(Mathf.Lerp(_startLeftRight.right, _newPos.right, daTime),
                Mathf.Lerp(_startLeftRight.top, _newPos.top, daTime));

            yield return new WaitForSeconds(_transitionTime / ticks);

        } while (ticksDone++ <= ticks);

        _isMenuVisable = _isMenuVisable ? false : true;
        if (_isClosing) _isClosing = false;

    }

    #endregion

}
