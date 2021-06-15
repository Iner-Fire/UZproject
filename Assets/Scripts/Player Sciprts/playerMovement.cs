using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
	public Gold gold;
	public KeySpawn keyspawn;
	public SpriteChange which;
	public Sprite potion_mv;
	public Sprite potion_in;
	public SpriteRenderer spriteRnd;
	bool isMoving = false;
	public int deathCounter = 0;
	public int maxHealth = 3;
	public int currentHealth;
	public float moveSpeed = 1f;
	public Vector2 movement;
	public Rigidbody2D rigibody;
	public Animator anim;
	public float hf = 0.0f;
	public float speed = 0.0f;
	public static AudioClip clip;
	AudioSource audioSrc;
	public keyPickup key;
	public Animator szop;
	public Animator Spikes;
	public SpeedrunTime time;
	public SpikesSpawn spikeSpawn;
	public SoundManagerScript sound;
	public int potions;
	public int trap;
	public int coins;
	public int torches;
	public int potion_mvspeed;
	public int potion_invisible;
	public int isChangdTimer = 0;
	int saveData = 0;
	public  GameObject FOGM;
	public GameObject torch;
	public int keyAmount;
	public openChest chest;
	public HealthBar healthBar;
	public Text textCounterTrap;
	public Text textCounterCoins;
	public Text textCounterPotion;
	public Text textCounterKeys;
	public Text textCounterTorch;
	public TorchScript saveTorch;
	public GameObject torchFab;
	public RespawnPoints respawn;
	public Camera FOGMC;
	public Camera FOGSC;
	int Respawn = 0;


    void Awake()
    {
        if (PlayerPrefs.GetInt("whichOne") == 1 && PlayerPrefs.GetInt("isChanged") == 1) 
        {
			spriteRnd.sprite = potion_in;
        }
        else if (PlayerPrefs.GetInt("whichOne") == 0 && PlayerPrefs.GetInt("isChanged") == 1)
        {
			spriteRnd.sprite = potion_mv;
        }
		if(PlayerPrefs.GetInt("death") == 1)
        {
			deathCounter = PlayerPrefs.GetInt("deathCounter");
		}
		if (PlayerPrefs.GetInt("saveData") == 1)
		{
				deathCounter = PlayerPrefs.GetInt("deathCounter");

				coins = PlayerPrefs.GetInt("goldAmount");
			
				torches = PlayerPrefs.GetInt("torchAmount");
			
				trap = PlayerPrefs.GetInt("trapAmount");
			
				potions = PlayerPrefs.GetInt("potionAmount");

				potion_invisible = PlayerPrefs.GetInt("potion_inv_amount");

				potion_mvspeed = PlayerPrefs.GetInt("potion_mvspeed_amount");

				key.key = PlayerPrefs.GetInt("keyAmount");




		}
		Scene currentScene1 = SceneManager.GetActiveScene();
		string sceneName1 = currentScene1.name;
		int done = 0;
		if(sceneName1 =="Maze1" && done == 0)
        {
			PlayerPrefs.DeleteKey("playerPosistionX");
			PlayerPrefs.GetFloat("playerPosistionY");
			PlayerPrefs.GetFloat("playerPosistionZ");
			done = 1;
		}
		
			
		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;
		/*if (sceneName == "Game" || sceneName == "Maze1" || sceneName == "Maze2")
		{
			
			if(PlayerPrefs.GetInt("respawn") == 1)
            {
				Destroy(GameObject.FindGameObjectWithTag("FOGM"));
				PlayerPrefs.SetInt("respawn", 0);
            }
			else
				DontDestroyOnLoad(FOGM);
			for (int i = 0; i < PlayerPrefs.GetFloat("CloneListCount"); i++)
			{
				Instantiate(torchFab, new Vector3(PlayerPrefs.GetFloat("Torchx" + i),
				PlayerPrefs.GetFloat("Torchy" + i),
				PlayerPrefs.GetFloat("Torchz" + i)), Quaternion.identity);
			}
			
		}*/
	}
    void Start()
	{
		keyspawn.SetKeySpawn();
		gold.GoldSpawn();
		audioSrc = GetComponent<AudioSource>();
		spikeSpawn.Spawn();
		respawn.Spawn();
		currentHealth = maxHealth;
		healthBar.SetMaxHP(maxHealth);
		rigibody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		FOGMC = GetComponent<Camera>();
		FOGSC = GetComponent<Camera>();


	}


	void Update()
	{
		
	
		TorchScript saveDataTorch = saveTorch.GetComponent<TorchScript>();
		SpeedrunTime timer = time.GetComponent<SpeedrunTime>();
		keyPickup keyCounter = key.GetComponent<keyPickup>();
		textCounterCoins.text = coins.ToString();
		if (chest.isChanged == 0)
			textCounterPotion.text = potions.ToString();
		else if (chest.isChanged == 1 && which.whichOne == 0)
			textCounterPotion.text = potion_mvspeed.ToString();
		else if (chest.isChanged == 1 && which.whichOne == 1)
			textCounterPotion.text = potion_invisible.ToString();
		textCounterTrap.text = trap.ToString();
		textCounterTorch.text = torches.ToString();
		textCounterKeys.text = keyCounter.key.ToString();

		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		movement = movement.normalized;
		hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
		speed = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
		if (movement.x < -0.01f)
		{
			this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
		}
		else
		{
			this.gameObject.transform.localScale = new Vector3(1, 1, 1);

		}
	

		anim.SetFloat("Horizontal", hf);
		anim.SetFloat("Vertical", movement.y);
		anim.SetFloat("Speed", speed);

	}
    private void OnApplicationQuit()
    {
		PlayerPrefs.DeleteAll();
    }
    void FixedUpdate()
	{
		rigibody.MovePosition(rigibody.position + movement * moveSpeed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("desk"))
		{
			shopDialog pop = GameObject.FindGameObjectWithTag("desk").GetComponent<shopDialog>();
			pop.PopUp();
		}
		
		
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("desk"))
			szop.SetTrigger("close");

	
		
	}

}

