using UnityEngine;
using System.Collections;

public class Kokica : MonoBehaviour {
	public int boja;
	// Use this for initialization
	public int brojac;
	public GameObject mainPanel;
	public GUIText scoreText;
	void Start () {
		brojac = 0;
		//ovo = new GUIText ();

	}

	
	// Update is called once per frame
	void Update () {
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
	public void displayMenu(){
		mainPanel.GetComponent<CanvasGroup>().interactable = true;
		mainPanel.GetComponent<CanvasGroup>().alpha = 1;
		scoreText.text= "Score: "+ brojac;
	}

	void OnCollisionEnter(Collision collision)
	{
		//ovo.text = "Score" + brojac.ToString ();
		//GameObject.Find("GameLogic").GetComponent<LevelLogic>().dodajScore();
		Destroy(collision.collider.gameObject);
		Destroy(gameObject);
	
	}

}
