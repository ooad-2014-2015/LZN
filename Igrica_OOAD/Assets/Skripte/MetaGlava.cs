using UnityEngine;
using System.Collections;

public class MetaGlava : MonoBehaviour {

	
	// Function called when the enemy is created
	void Start () { 
		//brojac = 0;
		// Add a vertical speed to the enemy
		//GetComponent<Rigidbody2D>().position = Vector3.zero;
		//GetComponent<Rigidbody2D>().position = Vector3.up;
		//GetComponent<Rigidbody2D>().velocity= new Vector2(GetComponent<Rigidbody2D>().velocity.y,speed); 
			
		// Make the enemy rotate on itself
		//GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-200, 200);
		
		// Destroy the enemy in 3 seconds,
		// when it is no longer visible on the screen
	//	Destroy(gameObject, 3);
	}


	/*void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == "kokica" )
		{
			Destroy(collision.collider.gameObject);
			Destroy(gameObject);
			brojac+=2;
			score.text="Score" + brojac;


		}
	}*/
}
