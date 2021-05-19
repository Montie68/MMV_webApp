using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDropZone : MonoBehaviour
{
    Transform m_originalParent;
    Transform m_dropZone;
    // the drag and drop compent
    DigitalRubyShared.FingersDragDropComponentScript m_DragNDrop;
    bool m_inDropZone = false;
   
    // Start is called before the first frame update
    void Start()
    {
        m_originalParent = this.transform.parent;

        if (GetComponent<DigitalRubyShared.FingersDragDropComponentScript>() != null)
            m_DragNDrop = GetComponent<DigitalRubyShared.FingersDragDropComponentScript>();
        else
            Debug.LogError("No Fingers Drage Drop Component");
    }
    private void Update()
    {
        // get the LongpressGesture
        DigitalRubyShared.GestureRecognizer r = m_DragNDrop.LongPressGesture;
        // check if the drag isn't executing
        if (r.State != DigitalRubyShared.GestureRecognizerState.Executing)
        {
            // Swap the parents if in or out of the drop zone
            if (m_inDropZone)
            {
                transform.SetParent(m_dropZone);
            }
            else
            {
                transform.SetParent(m_originalParent);
            }
        }
        else
        {
            Canvas[] _canvases = FindObjectsOfType<Canvas>();
            foreach (Canvas c in _canvases)
            {
                if (c.name == "MainCanvas") transform.SetParent(c.transform);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.name == "dropzone")
        {
            m_inDropZone = true;
            m_dropZone = other.transform;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.transform.name == "dropzone")
        {
            m_inDropZone = false;
        }
    }
}
