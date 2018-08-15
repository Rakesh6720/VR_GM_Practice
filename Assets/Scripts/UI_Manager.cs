using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject PlayerMenuPrefab;


	// Use this for initialization
	void Start ()
	{

        //Instantiate instances of prefab capsules for each player object in the PlayerDictionary

        //On-click, instantiate the Menu prefab
	    GameObject newMenu = Instantiate(PlayerMenuPrefab);

	    //Connect the capsule instance ID to the player object ID

	    //Connect the player object ID to the player image ID

	    //Get the player image ID as a string from the player object image property

	    //--SKIP FOR TEXT COMPONENT

	    //Use that image ID string to locate the image file in the Asset folder structure

	    //Using the image ID and the image's Asset folder path, save the image as a Texture variable

	    //--RESUME FOR TEXT COMPONENT

	    //Connect the Texture variable to the Raw Image component on the Image Panel of the Canvas Parent UI

	    //
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
