using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
	private int sceneIndex;
	public float moveSpeed = 1f;
	public Vector2 movement;
	public Rigidbody2D rigibody;
	public Animator anim;
	public float hf = 0.0f;
	public float speed = 0.0f;
	private bool move;
	public int keyIlosc;
	AudioSource source;
	public AudioClip clip;
	public keyPickup key;
	public Animator szop;
	public int potions;
	public int trap;
	public int coins;
	public int torches;
	public Text textCounterTrap;
	public Text textCounterCoins;
	public Text textCounterPotion;
	public Text textCounterKeys;
	public Text textCounterTorch;

	// Use this for initialization
	void Start()
	{
		rigibody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
		this.transform.position = new Vector3(PlayerPrefs.GetFloat("playerPosistionX"),
		PlayerPrefs.GetFloat("playerPosistionY"),
		PlayerPrefs.GetFloat("playerPosistionZ"));

	}

	// Update is called once per frame
	void Update()
	{
		textCounterCoins.text = coins.ToString();
		textCounterPotion.text = potions.ToString();
		textCounterTrap.text = trap.ToString();
		textCounterTorch.text = torches.ToString();

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
			PlayerPrefs.SetFloat("playerPosistionX", this.gameObject.transform.position.x);
			PlayerPrefs.SetFloat("playerPosistionY", this.gameObject.transform.position.y);
			PlayerPrefs.SetFloat("playerPosistionZ", this.gameObject.transform.position.z);
			PlayerPrefs.SetInt("keyAmount", key.key);
			PlayerPrefs.Save();
			SceneManager.LoadScene("EscOptions");
		}

		anim.SetFloat("Horizontal", hf);
		anim.SetFloat("Vertical", movement.y);
		anim.SetFloat("Speed", speed);

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
        }
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
		szop.SetTrigger("close");
		if (collision.gameObject.CompareTag("Glue"))
		{
			moveSpeed *= 3;
		}
	}
}

