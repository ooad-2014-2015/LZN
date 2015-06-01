using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

	public enum TimerType {CountDown};
	public TimerType timer=TimerType.CountDown;
	public List<GameObject> prate= new List<GameObject>();
	public List<GameObject> suprate= new List<GameObject>();
	public GUIText text;

	public float TimeInSec=60f;
	// Use this for initialization
	void Start () {
		StartCoroutine (CountDown());	
	}
	
	IEnumerator CountDown()
	{
		while(TimeInSec>0)
		{
			yield return new WaitForSeconds(1);
			TimeInSec--;
			UpdateText(TimeInSec);
		}
		//GameObject.Find("GameLogic").GetComponent<Kokica>().displayMenu();

	}

	void UpdateText(float amount)
	{
		text.text=Mathf.Max(0,amount).ToString();


	}
}
