using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovementShop : MonoBehaviour
{
	int currentHealth;
	int maxHP;
	public GameObject Menu;
	public HealthBar healthBar;
	public int potion_mvspeed;
	public int potion_invisible;
	public int deathCounter = 0;
	public SpriteRenderer spriteRnd;
	public Sprite potion_in;
	public Sprite potion_mv;
	public float moveSpeed = 1f;
	public Vector2 movement;
	public Rigidbody2D rigibody;
	public Animator anim;
	public float hf = 0.0f;
	public float speed = 0.0f;
	public keyPickup key;
	public Animator szop;
	public int potions;
	public int trap;
	public int coins;
	public int torches;
	public int isChangdTimer = 0;
	int saveData = 0;
	public int keyAmount;
	public Text textCounterCoins;
	public Text textCounterPotion;
	public Text textCounterTrap;
	public Text textCounterKeys;
	public Text textCounterTorch;


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
		GameObject FOGM = GameObject.FindGameObjectWithTag("FOGM");
		GameObject FOGS = GameObject.FindGameObjectWithTag("FOGS");
		GameObject FOGC = GameObject.FindGameObjectWithTag("FOGC");
		if(FOGM && FOGS && FOGC)
        {
			Destroy(FOGM);
			Destroy(FOGS);
			Destroy(FOGC);
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
			
			

		}

	}
	void Start()
	{
		maxHP = currentHealth;
		healthBar.SetMaxHP(maxHP);
		rigibody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}

	
	void Update()
	{
		keyPickup keyCounter = key.GetComponent<keyPickup>();
		textCounterCoins.text = coins.ToString();
		if (PlayerPrefs.GetInt("isChanged") ==0)
			textCounterPotion.text = potions.ToString();
		else if (PlayerPrefs.GetInt("whichOne") == 0 && PlayerPrefs.GetInt("isChanged") == 1)
			textCounterPotion.text = potion_mvspeed.ToString();
		else if (PlayerPrefs.GetInt("whichOne") == 1 && PlayerPrefs.GetInt("isChanged") == 1)
			textCounterPotion.text = potion_invisible.ToString();
		textCounterTrap.text = trap.ToString();
		textCounterTorch.text = torches.ToString();
		textCounterKeys.text = key.key.ToString();

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
			Menu.SetActive(false);
			shopDialog pop = GameObject.FindGameObjectWithTag("desk").GetComponent<shopDialog>();
			pop.PopUp();
		}
		
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("desk"))
		{
			Menu.SetActive(true);
			szop.SetTrigger("close");
		}
		
	}
}


