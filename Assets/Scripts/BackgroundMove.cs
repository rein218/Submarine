using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed;
    public Transform fon1;
    public Transform fon2;

	void Update()
    {
        if (fon1.position.x <= -5.60f)
        {
            fon1.position = new Vector3(5.60f, 0, 0);

        }
        if (fon2.position.x <= -5.60f)
        {
            fon2.position = new Vector3(5.60f, 0, 0);

        }
		transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

		
	}
}
