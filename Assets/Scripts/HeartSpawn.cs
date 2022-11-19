using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawn : MonoBehaviour
{
	public GameObject heartPrefab;
	public float respawnTime = 1.0f;
	private Vector2 screenBounds;

	// Start is called before the first frame update
	void Start()
    {
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine(objectWave());
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void spawnObject()
	{
		GameObject a = Instantiate(heartPrefab) as GameObject;
		a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
	}

	IEnumerator objectWave()
	{
		while (true)
		{
			yield return new WaitForSeconds(respawnTime);
			spawnObject();
		}

	}
}
