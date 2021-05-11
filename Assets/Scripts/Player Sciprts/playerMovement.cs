using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
	public int deathCounter = 0;
	public int maxHealth = 3;
	public int currentHealth;
	public float moveSpeed = 1f;
	public Vector2 movement;
	public Rigidbody2D rigibody;
	public Animator anim;
	public float hf = 0.0f;
	public float speed = 0.0f;
	public AudioClip clip;
	public keyPickup key;
	public Animator szop;
	public SpeedrunTime time;
	public int potions;
	public int trap;
	public int coins;
	public int torches;
	public int isChangdTimer = 0;
	int saveData = 0;
	public  GameObject FOGM;
	public GameObject torch;
	public int keyAmount;
	public HealthBar healthBar;
	public Text textCounterTrap;
	public Text textCounterCoins;
	public Text textCounterPotion;
	public Text textCounterKeys;
	public Text textCounterTorch;
	public TorchScript saveTorch;
	public GameObject torchFab;
	public RespawnPoints respawn;
	int Respawn = 0;


    void Awake()
    {
		
		if (PlayerPrefs.GetInt("saveData") == 1)
		{
				deathCounter = PlayerPrefs.GetInt("deathCounter");

				coins = PlayerPrefs.GetInt("goldAmount");
			
				torches = PlayerPrefs.GetInt("torchAmount");
			
				trap = PlayerPrefs.GetInt("trapAmount");
			
				potions = PlayerPrefs.GetInt("potionAmount");
			/*if (PlayerPrefs.GetInt("respawn") == 1)
				respawn.Spawn();*/
			
		}
		if (PlayerPrefs.GetInt("respawn") == 0)
		{
			this.transform.position = new Vector3(PlayerPrefs.GetFloat("playerPosistionX"),
			PlayerPrefs.GetFloat("playerPosistionY"),
			PlayerPrefs.GetFloat("playerPosistionZ"));
		}
		/*else if (PlayerPrefs.GetInt("respawn") == 1)
			respawn.Spawn();
*/
		Scene currentScene = SceneManager.GetActiveScene();
		string sceneName = currentScene.name;
		if (sceneName == "Game")
		{
			DontDestroyOnLoad(FOGM);
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
			
		}
	}
    void Start()
	{
		respawn.Spawn();
		currentHealth = maxHealth;
		healthBar.SetMaxHP(maxHealth);
		rigibody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{
		TorchScript saveDataTorch = saveTorch.GetComponent<TorchScript>();
		SpeedrunTime timer = time.GetComponent<SpeedrunTime>();
		keyPickup keyCounter = key.GetComponent<keyPickup>();
		textCounterCoins.text = coins.ToString();
		textCounterPotion.text = potions.ToString();
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
		/*if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Verical") <= 0.01f || Input.GetAxis("Horizontal") <= 0.01f)
        {
			source.Play();
        }
        else if(Input.GetAxis("Verical") ==0 || Input.GetAxis("Horizontal") == 0)
        {
			source.Stop();
        }*/

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (saveDataTorch.cloneList.Count > 0)
			{
				for (int i = 0; i < saveDataTorch.cloneList.Count; i++)
				{
					PlayerPrefs.SetFloat("Torchx" + i, saveDataTorch.cloneList[i].transform.position.x);
					PlayerPrefs.SetFloat("Torchy" + i, saveDataTorch.cloneList[i].transform.position.y);
					PlayerPrefs.SetFloat("Torchz" + i, saveDataTorch.cloneList[i].transform.position.z);
					PlayerPrefs.SetFloat("CloneListCount", saveDataTorch.cloneList.Count);
				}
			}
			PlayerPrefs.SetFloat("playerPosistionX", this.gameObject.transform.position.x);
			PlayerPrefs.SetFloat("playerPosistionY", this.gameObject.transform.position.y);
			PlayerPrefs.SetFloat("playerPosistionZ", this.gameObject.transform.position.z);
			PlayerPrefs.SetFloat("timer_m", timer.minutes);
			PlayerPrefs.SetFloat("timer_s", timer.seconds);
			PlayerPrefs.SetFloat("start", timer.start);
			isChangdTimer = 1;
			PlayerPrefs.SetInt("isChangedTimer", isChangdTimer);



			PlayerPrefs.SetInt("goldAmount", coins);
			PlayerPrefs.SetInt("torchAmount", torches);
			PlayerPrefs.SetInt("potionAmount", potions);
			PlayerPrefs.SetInt("trapAmount", trap);
			saveData = 1;
			PlayerPrefs.SetInt("saveData", saveData);
			PlayerPrefs.Save();
			SceneManager.LoadScene("EscOptions");
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
		if(collision.gameObject.CompareTag("Glue"))
        {
			moveSpeed /= 3;
			currentHealth -= 1;
			if (currentHealth == 0)
			{
				deathCounter++;
				PlayerPrefs.SetInt("deathCounter", deathCounter);
				Respawn = 1;
				PlayerPrefs.SetInt("respawn", Respawn);
				SceneManager.LoadScene("Game");
	


			}
				
			
			healthBar.SetHP(currentHealth);
        }
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("desk"))
			szop.SetTrigger("close");

		if (collision.gameObject.CompareTag("Glue"))
		{
			moveSpeed *= 3;
		}
	}
}

