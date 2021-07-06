using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AutoSizeLayoutGroup : MonoBehaviour
{
	#region Public
	//public members go here
	public RectTransform rectTransform;
	public bool isDynamic = false;
	public bool usingHorizontalLayout;
	public int endBuffer = 0;
	#endregion

	#region Private
	//private members go here
	private RectTransform[] selectableObjects;
	private HorizontalOrVerticalLayoutGroup layoutGroup;
  #endregion
  // Place all unity Message Methods here like OnCollision, Update, Start ect. 
  #region Unity Messages 
    void Start()
    {
        Resize();

    }


    private void LateUpdate()
    {
		if (isDynamic)
			Resize();
    }

    #endregion
    #region Public Methods
    //Place your public methods here

    #endregion
    #region Private Methods
    //Place your public methods here
    private void Resize()
    {
        selectableObjects = GetComponentsInChildren<RectTransform>();
        List<RectTransform> objs = new List<RectTransform>();
        foreach(RectTransform r in selectableObjects)
        {
            if (r.parent == this.rectTransform) objs.Add(r);
        }
        float heightOrWitdh = 0f;

        if (usingHorizontalLayout)
        {
            layoutGroup = GetComponent<HorizontalLayoutGroup>();
            heightOrWitdh += layoutGroup.padding.left + layoutGroup.padding.right;
            heightOrWitdh += layoutGroup.spacing * (objs.Count - 1);

        }
        else
        {
            layoutGroup = GetComponent<VerticalLayoutGroup>();
            heightOrWitdh += layoutGroup.padding.top + layoutGroup.padding.bottom;
            heightOrWitdh += layoutGroup.spacing * (objs.Count - 1);
        }
        foreach (RectTransform s in objs)
        {
            if (usingHorizontalLayout)
            {
                heightOrWitdh += s.GetComponent<RectTransform>().sizeDelta.x;
            }
            else
            {
                heightOrWitdh += s.GetComponent<RectTransform>().sizeDelta.y;
            }
        }
        RectTransform rt;
        if (rectTransform == null)
            rt = gameObject.GetComponent<RectTransform>();
        else
            rt = rectTransform;

        if (usingHorizontalLayout)
        {
            rt.sizeDelta = new Vector2(heightOrWitdh + endBuffer, rt.sizeDelta.y);
        }
        else
        {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (heightOrWitdh + endBuffer));


        }
    }

    #endregion

}
