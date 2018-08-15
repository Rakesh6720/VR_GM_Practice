using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//THIS SCRIPT HANDLES PLAYER OBJECT CREATION FROM LIBRARY AND STATIC GENERATION OF RAW IMAGE TEXTURE
public class DoStuff : MonoBehaviour
{
    // Use this for initialization
    void Start ()
	{
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
	    plane.AddComponent<Collider>();
        plane.transform.localScale = new Vector3(10f, 1f, 10f);

        Player Aaron = new Player("Aaron", 1f, "Doin' Thangs");
        Player Jordy = new Player("Jordy", 2f, "Don't Trade Me, Bro");

        Dictionary<float, Player> playerDictionary = new Dictionary<float, Player>
        {
            { Aaron.Id, Aaron },
            { Jordy.Id, Jordy }
        };

	    Dictionary<float, string> playerImageDemo = new Dictionary<float, string>
	    {
	        {1f, "Aaron"},
	        {2f, "Jordy"}
	    };

	    Dictionary<float, CapsuleGuy> playerCapsuleDictionary = new Dictionary<float, CapsuleGuy>();

       foreach (var player in playerDictionary)
	    {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
	        capsule.AddComponent<Rigidbody>();
            capsule.transform.position = new Vector3(player.Key, 0, 0);
	        capsule.AddComponent<Text>();
            Text burgertime2 = capsule.GetComponent<Text>();
	        burgertime2.text = player.Value.Motto;	  
            CapsuleGuy capsuleInstance = new CapsuleGuy(player.Key, capsule, player.Value);
            playerCapsuleDictionary.Add(capsuleInstance.Id, capsuleInstance);
	    }

	    foreach (var capsuleInstance in playerCapsuleDictionary)
	    {
	        capsuleInstance.Value.CapsuleBody.AddComponent<Button>();
	    
	        Button infoButton = capsuleInstance.Value.CapsuleBody.GetComponent<Button>();
	        AssetDatabase.ImportAsset("Assets/Textures and Sprites/Rounded UI/UIButtonDefault.png", ImportAssetOptions.Default);
            Graphic teezer = AssetDatabase.LoadAssetAtPath("Assets/Textures and Sprites/Rounded UI/UIButtonDefault.png", typeof(Image)) as Graphic;

	        infoButton.targetGraphic = teezer;

	    }

        //GameObject playerFrame = new GameObject();
        //playerFrame.AddComponent<Canvas>();
        //Canvas playerFrameCanvas = playerFrame.GetComponent<Canvas>();
        //playerFrameCanvas.enabled = false;

	    AssetDatabase.ImportAsset("Assets/Images/Resources/001.jpg", ImportAssetOptions.Default);
	    Texture2D t = AssetDatabase.LoadAssetAtPath("Assets/Images/Resources/001.jpg", typeof(Texture2D)) as Texture2D;

	    var canvas = GameObject.Find("Canvas");
	    canvas.AddComponent<RawImage>();
	    RawImage rawzer = canvas.GetComponent<RawImage>();
	    rawzer.texture = t;




    }

    public class ImportAsset : MonoBehaviour
    {
        [MenuItem("AssetDatabase/ImportExample")]
        public static void IngestAsset()
        {
            AssetDatabase.ImportAsset("Assets/Images/Resources/001.jpg", ImportAssetOptions.Default);
        }

        public static void LoadAsset()
        {
            Texture2D t = AssetDatabase.LoadAssetAtPath("Assets/Images/Resources/001.jpg", typeof(Texture2D)) as Texture2D;
        }
    }


    public class CapsuleGuy : MonoBehaviour
    {
        public float Id;
        public GameObject CapsuleBody;
        public Player CapsulePlayer;

        public CapsuleGuy(float id, GameObject capsuleBody, Player capsulePlayer)
        {
            this.Id = id;
            this.CapsuleBody = capsuleBody;
            this.CapsulePlayer = capsulePlayer;
        }
    }



    public class Player : MonoBehaviour
    {
        public string Name;
        public float Id;
        public string Motto;

        public Player (string name, float id, string motto)
        {
            this.Name = name;
            this.Id = id;
            this.Motto = motto;
        }
    }
}
