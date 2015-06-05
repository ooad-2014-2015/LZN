using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Kokica : MonoBehaviour {
	public int boja;
	// Use this for initialization
	public static int brojac=0;
	public GameObject mainPanel;

	public enum TimerType {CountDown};
	public TimerType timer=TimerType.CountDown;
	public List<GameObject> prate= new List<GameObject>();
	public List<GameObject> suprate= new List<GameObject>();
	//public GUIText text;
	
	public float TimeInSec=60f;
	void Start () {
		//brojac = 0;
		//ovo = new GUIText ();

	}

	
	// Update is called once per frame
	void Update () {
		UpdateText(brojac);
		if(transform.position.y<-6 || transform.position.y>6){		
			Destroy(gameObject);
		}

	}
	/*void OnTriggerEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == "glava")
		{
			Destroy(collision.collider.gameObject);
			Destroy(gameObject);
		}
	}*/
/*	public void displayMenu(){
		mainPanel.GetComponent<CanvasGroup>().interactable = true;
		mainPanel.GetComponent<CanvasGroup>().alpha = 1;
		scoreText.text= "Score: "+ brojac;
	}*/

	void OnCollisionEnter(Collision collision)
	{
		brojac += 10;
		//Score.UpdateScore (brojac);
		//ovo.text = "Score" + brojac.ToString ();
		//GameObject.Find("GameLogic").GetComponent<LevelLogic>().dodajScore();
		Destroy(collision.collider.gameObject);
		Destroy(gameObject);
	
	}

	void UpdateText(float amount)
	{
		//text.text="Score: " + Mathf.Max(0,amount).ToString();
		
		
	}

}
