using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class OpenPanel : MonoBehaviour
{
    [SerializeField] GameObject m_scrollPanel;
    [SerializeField] List<GameObject> m_PanelsToHide;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Button>() != null)  

            GetComponent<Button>().onClick.AddListener(delegate 
            {
                m_scrollPanel.SetActive(m_scrollPanel.activeSelf ? false : true);
                foreach (GameObject gmObj in m_PanelsToHide)
                {
                    gmObj.SetActive(false);
                }
            }); 
        else 
            Debug.LogError("No Button Attached");
    }


}
