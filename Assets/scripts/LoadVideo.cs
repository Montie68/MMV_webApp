using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVideo : MonoBehaviour
{
    #region Public
    //public members go here
    public string videoUrl;

    #endregion

    #region Private
    //private members go here
    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Public Methods
    //Place your public methods here
    public void LoadTheVideo()
    {
        if (GameObject.FindObjectOfType<LoadExternalVideos>() != null)
        {
            GameObject.FindObjectOfType<LoadExternalVideos>().ShowTheVideo(videoUrl);
        }
        else Debug.LogError("No Load Extrenal Video Component Found!!!");
    }
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
