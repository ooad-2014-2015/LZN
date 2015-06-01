using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLogic : MonoBehaviour {
	public GameObject mainPanel;//panel meni koji iskoci
	public Text scoreText;//referenca na text labelu za score
	public int score = 0;//poeni
	// Use this for initialization
	void Start () {
		hideMenu();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void dodajScore(){//poziva se pri koliziji metka i mete
		score++;
	}
	
	public void displayMenu(){
		mainPanel.GetComponent<CanvasGroup>().interactable = true;
		mainPanel.GetComponent<CanvasGroup>().alpha = 1;
		scoreText.text= "Score: "+ score;
	}
	
	public void hideMenu(){
		//sakrij meni i onemoguci interakciju
		mainPanel.GetComponent<CanvasGroup>().interactable = false;
		mainPanel.GetComponent<CanvasGroup>().alpha = 0;
	}
	
	public void ponovi(){
		Application.LoadLevel("MainScena");
	}
	
	public void exit(){
		Application.LoadLevel("MenuScena");
	}
}
