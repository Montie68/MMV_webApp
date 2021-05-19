using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
public class LoadText : MonoBehaviour
{
    public enum TEXTFIELD
    {
        none,
        info_1,
        info_2,
    }

    [SerializeField] TEXTFIELD m_textFeildToLoad = TEXTFIELD.none;
    [SerializeField] TMPro.TextMeshProUGUI m_textMeshFeild;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(LoadTheText());
    }

    private IEnumerator LoadTheText()
    {
        string file = Application.streamingAssetsPath + "/textfeilds.json";
        // WebRequest Test Link
        // file = "http://localhost/vhosts/mmv/StreamingAssets/textfeilds.json";
        var arr = JSON.Parse("[]");


        if (file.Contains("://") || file.Contains(":///"))
        {
            UnityWebRequest www = UnityWebRequest.Get(file);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError) Debug.Log(www.error);
            arr = JSON.Parse(www.downloadHandler.text);
        }
        else if (File.Exists(file))
        {
            arr = JSON.Parse(File.ReadAllText(file));
        }
          string key = m_textFeildToLoad.ToString();

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].HasKey(key))
                {
                    m_textMeshFeild.text = arr[i][key];
                }
            }
        yield return null;
    }
}
