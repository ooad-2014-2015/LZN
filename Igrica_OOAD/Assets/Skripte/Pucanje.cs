using UnityEngine;
using System.Collections;

public class Pucanje : MonoBehaviour {

	public float brzina=15f;
	public GameObject kokica;
	public GameObject ispali;
	public float brojac=-2;
	private static float cooldownAmount = 0.3f;
	private int boja =0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	if (Input.GetMouseButton(0) && brojac < 0) 
		{
			GameObject mojMetak = (GameObject) Instantiate(kokica, transform.position, transform.rotation);
			//mojMetak.transform.position=ispali.transform.position;
			Vector3 meta = Camera.main.ScreenToWorldPoint(Input.mousePosition);//iz koordinata 
			//ekrana gdje je mis nadji u 3d prostoru koja je to tacka
			meta=Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			meta.z = 0;//da ne bi metak otisao u trecu dimenziju

			//AudioSource.PlayClipAtPoint(pucanjeSound,transform.position);
			mojMetak.GetComponent<Rigidbody>().velocity = meta.normalized*brzina - transform.position;//pocetno ubrzanje
			brojac=cooldownAmount;
		}
		brojac -= Time.deltaTime;
	}
}
