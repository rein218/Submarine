using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
	public float speed = 2.0f;
	private Rigidbody2D rb;
	private Vector2 screenBounds;

	void Start()
    {
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed, 0);
	}

    void Update()
    {
		if (transform.position.x < screenBounds.x - 8)
		{
			Destroy(this.gameObject);
		}
	}

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
        {
            MoneyText.Coin += 1;
            Destroy(gameObject);      
        }  
    }
}
