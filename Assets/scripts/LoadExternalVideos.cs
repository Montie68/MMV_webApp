using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;

public class LoadExternalVideos : MonoBehaviour
{
    #region Public
    //public members go here
    public static LoadExternalVideos loadExternalVideos;
    #endregion

    #region Private
    //private members go here
    [DllImport("__Internal")]
    private static extern void PlayVideo(string url);

    #endregion
    // Place all unity Message Methods here like OnCollision, Update, Start ect. 
    #region Unity Messages 
    // Start is called before the first frame update
    private void Awake()
    {
        if (loadExternalVideos != null)
        {
            Destroy(this.gameObject);
        }
        loadExternalVideos = this;
    }
    #endregion
    #region Public Methods
    public void ShowTheVideo(string url)
    {
        Debug.Log("Playing: " + url);

#if UNITY_EDITOR
        return;
#endif

#if UNITY_WEBGL
#pragma warning disable CS0162
        PlayVideo(url);
#pragma warning restore CS0162

#endif

    }
    //Place your public methods here
    #endregion
    #region Private Methods
    //Place your public methods here

    #endregion

}
