using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DoPlayerButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

	    AssetDatabase.ImportAsset("Assets/Images/Resources/001.jpg", ImportAssetOptions.Default);
	    Texture2D t = AssetDatabase.LoadAssetAtPath("Assets/Images/Resources/001.jpg", typeof(Texture2D)) as Texture2D;

	    var canvas = GameObject.Find("Canvas");
	    canvas.AddComponent<RawImage>();
	    RawImage rawzer = canvas.GetComponent<RawImage>();
	    rawzer.texture = t;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
