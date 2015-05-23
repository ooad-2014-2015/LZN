using UnityEngine;
using System.Collections;

public class Kokica : MonoBehaviour {
	public int boja;
	// Use this for initialization
	public int brojac;
	public GUIText ovo;
	void Start () {
		brojac = 0;
	//	ovo = GetComponent<GUIText> ();
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

	void OnCollisionEnter(Collision collision)
	{
		brojac+=2;
	//	ovo.text="Score" + brojac;

		Destroy(collision.collider.gameObject);
		Destroy(gameObject);
	
	}

}
