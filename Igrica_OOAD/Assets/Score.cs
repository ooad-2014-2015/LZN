using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	public GUIText text;
	//public  static int brojac=0;
	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		UpdateScore ();
		
	}
	public  void UpdateScore()
	{
		Ispisi (Kokica.brojac);

	}
	 void Ispisi(int br)
	{
		text.text="Score: "+ Mathf.Max(0,br).ToString();
	}

	// Update is called once per frame

}
