using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAndHealthMove : MonoBehaviour
{
	public float speed = 1.0f;
	private Rigidbody2D rb;
	private Vector2 screenBounds;

	// Start is called before the first frame update
	void Start()
    {
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed, 0);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	}

    // Update is called once per frame
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
			Destroy(gameObject);
		}
	}
}
