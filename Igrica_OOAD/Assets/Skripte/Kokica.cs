using UnityEngine;
using System.Collections;

public class Kokica : MonoBehaviour {

	void Start()
	{

	}
	
	void Update()
	{

		/*Vector2 position = transform.position;
		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
		transform.position = position;
		//Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));*/

		if (transform.position.x<-6 || transform.position.x > 6 || transform.position.y > 6)
		{
			Destroy(gameObject);
		}
	}
}
