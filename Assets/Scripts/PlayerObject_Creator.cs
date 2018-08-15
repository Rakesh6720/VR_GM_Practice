using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayerObject_Creator : MonoBehaviour
{
    public GameObject playerPreFab;
    public GameObject PlayerMenuPrefab;
    private Dictionary<int, Player> _playerCapsuleDictionary = new Dictionary<int, Player>();
    private readonly Dictionary<float, Player> PlayerDictionary = new Dictionary<float, Player>();
    private int playerCapsuleId;

	// Use this for initialization
    void Start()
    {

        Player Aaron = new Player(001, "Aaron Rodgers", "R-E-L-A-X", 001);
        Player Jordy = new Player(002, "Jordy Nelson", "Ouch, my hamstring!", 002);

        Dictionary<float, Player> PlayerDictionary = new Dictionary<float, Player>
        {
            {001, Aaron},
            {002, Jordy}
        };

        //Instantiate instances of prefab capsules for each player object in the PlayerDictionary
        foreach (var player in PlayerDictionary)
        {
            var playerCapsule = Instantiate(playerPreFab, new Vector3(player.Key, 0.3f, 0), Quaternion.identity);
            playerCapsuleId = playerCapsule.GetInstanceID();

            //Connect the capsule instance ID to the player object
            _playerCapsuleDictionary.Add(playerCapsuleId, player.Value);
        }
    }

    public void GenerateMenu()
    { 
        //On-click, instantiate the Menu prefab
	    GameObject newMenu = Instantiate(PlayerMenuPrefab);

        //Connect the player object ID to the player image ID

        //Get the player image ID as a string from the player object image property

        //--SKIP FOR TEXT COMPONENT

        //Use that image ID string to locate the image file in the Asset folder structure
	    AssetDatabase.ImportAsset("Assets/Images/Resources/001.jpg", ImportAssetOptions.Default);

        //Using the image ID and the image's Asset folder path, save the image as a Texture variable
	    Texture2D t = AssetDatabase.LoadAssetAtPath("Assets/Images/Resources/001.jpg", typeof(Texture2D)) as Texture2D;

        //--RESUME FOR TEXT COMPONENT

        //Connect the Texture variable to the Raw Image component on the Image Panel of the Canvas Parent UI
        var rawImager = newMenu.GetComponentInChildren(typeof(RawImage));

	    RawImage rawzer = rawImager.GetComponent<RawImage>();
	    rawzer.texture = t;

        var texter = newMenu.GetComponentInChildren(typeof(Text));
        Text texturizer = texter.GetComponent<Text>();
        texturizer.text = "Aaron Rodgers";
        //Player newPlayer = PlayerDictionary[001];
        //texturizer.text = newPlayer.Motto;
    }

  


    public class Player : MonoBehaviour
    {
        public float Id { get; set; }
        public string FullName { get; set; }
        public string Motto { get; set; }
        public float ImageId { get; set; }

        public Player(float id, string fullName, string motto, float imageId)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Motto = motto;
            this.ImageId = imageId;
        }
    }

    public class PlayerCapsule
    {
        public int Id { get; set; }
        public float PlayerId { get; set; }

    }
}
