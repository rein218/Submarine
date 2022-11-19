using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce;
    Rigidbody2D rb;
    public GameObject GM;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Force);
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Rock"))
		{
			HealthBar.Health -= 20;
            if (HealthBar.Health <= 0)
            {
                GM.GetComponent<GameManagerMenu>().Death();
            }
        }
		if (other.CompareTag("Health"))
		{
			HealthBar.Health += 20;
		}
    }
    
    public void colorSwap()
    {
        if (PlayerPrefs.GetInt("choosedSkin") == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        if (PlayerPrefs.GetInt("choosedSkin") == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color32(37, 59, 238, 255);
        }
        if (PlayerPrefs.GetInt("choosedSkin") == 2)
        {
            GetComponent<SpriteRenderer>().color = new Color32(245, 180, 0, 255);
        }

    }
   
}
