using System.Collections;
using UnityEngine;

//THIS SCRIPT HANDLES IMPORTING AN IMAGE TEXTURE FROM THE INTERNET AND ATTACHING TO CAMERA
public class LoadImage : MonoBehaviour
{
    private string url = "https://clutchpoints.com/wp-content/uploads/2017/12/Aaron-Rodgers-1-1024x575.jpg";
    private Texture2D _img;

    public Texture2D Img
    {
        get { return _img; }
        
    }


    // Use this for initialization
    void Start()
    {
            StartCoroutine(LoadImg());
    }

    IEnumerator LoadImg()
    {
        yield return 0;
        WWW imgLink = new WWW(url);
        yield return imgLink;
        _img = imgLink.texture;
    }

    //// Update is called once per frame
    ////void OnGUI()
    ////{
    ////    GUILayout.Label(img);
    ////}


}
