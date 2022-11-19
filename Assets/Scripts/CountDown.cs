using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
	public float timeStart = 0;
	public Text textBox;   

    void Update()
    {
		timeStart += Time.deltaTime;
		textBox.text = Mathf.Round(timeStart).ToString();
	}


	void Start()
	{
		textBox.text = timeStart.ToString();
	}
}
