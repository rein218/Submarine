using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//HealthBar-----------------------------------------------------------
	public Image HealthBare;
	public Image HealthBarEffect;
	float MaxHealth = 100f;
	public static float Health;
	public float HealthSpeed;
	//MoneyText-----------------------------------------------------------
	public static int Coin;
	Text text;
	//BackgroundMove------------------------------------------------------
	public float speeed;
	public Transform fon1;
	public Transform fon2;
	//CountDown-----------------------------------------------------------
	public float timeStart = 0;
	public Text textBox;
	//RockAndHealthMove---------------------------------------------------
	public float speed = 1.0f;
	private Rigidbody2D rb;
	//DeployObjects-------------------------------------------------------
	public GameObject rockPrefab;
	public float respawnTime = 1.0f;
	private Vector2 screenBounds;
	//--------------------------------------------------------------------

	void Start()
    {
		//HealthBar-------------------------------------------------------
		HealthBare = GetComponent<Image>();
		Health = MaxHealth;
		//MoneyText-------------------------------------------------------
		text = GetComponent<Text>();
		//CountDown-------------------------------------------------------
		textBox.text = timeStart.ToString();
		//RockAndHealthMove-----------------------------------------------
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed, 0);
		//DeployObjects-----------------------------------------------------------------------------------------------------------
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine(objectWave());
		//------------------------------------------------------------------------------------------------------------------------
	}

    void Update()
    {
		//HealthBar-------------------------------------------------------
		HealthBare.fillAmount = Health / MaxHealth;
		if (HealthBarEffect.fillAmount > HealthBare.fillAmount)
		{
			HealthBarEffect.fillAmount -= HealthSpeed;
			
		}
		else
		{
			HealthBarEffect.fillAmount = HealthBare.fillAmount;
		}
		//MoneyText-------------------------------------------------------
		text.text = Coin.ToString();		
		//CountDown-------------------------------------------------------
		timeStart += Time.deltaTime;
		textBox.text = Mathf.Round(timeStart).ToString();
		//----------------------------------------------------------------
		
	}
    private void FixedUpdate()
    {
		//BackgroundMove--------------------------------------------------
		if (fon1.position.x <= -5.60f)
		{
			fon1.position = new Vector3(5.60f, 0, 0);

		}
		if (fon2.position.x <= -5.60f)
		{
			fon2.position = new Vector3(5.60f, 0, 0);

		}
		transform.position += new Vector3(-speeed * Time.deltaTime, 0, 0);
	}
    //DeployObjects-------------------------------------------------------------------------------------------
    private void spawnObject()
	{
		GameObject c = Instantiate(rockPrefab) as GameObject;
		c.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
	}

	IEnumerator objectWave()
	{
		while (true)
		{
			yield return new WaitForSeconds(respawnTime);
			spawnObject();
		}

	}
	//---------------------------------------------------------------------------------------------------------
	
}
