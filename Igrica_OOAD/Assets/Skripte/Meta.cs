using UnityEngine;
using System.Collections;

public class Meta : MonoBehaviour {
	//public AudioClip explozijaSound;
	public float brzina;//brzina padanja
	public GameObject refParticle;
	public int boja =0;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		//svaki frame pomjerimo po y osi za zadanu brzinu
		transform.position = transform.position - new Vector3(0,brzina * Time.deltaTime,0);
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == "Metak")
		{
			Debug.Log(boja + " " + collision.collider.gameObject.GetComponent<Kokica>().boja);
			if(collision.collider.gameObject.GetComponent<Kokica>().boja==boja){
				Destroy(collision.collider.gameObject);//unisti metak
				//postaviti efekat na poziciju objekta
				refParticle.transform.position=transform.position;
				//Pozovi emitovanje cestica Particle Emit
				refParticle.gameObject.transform.GetComponent<ParticleSystem>().startColor = GetComponent<Renderer>().material.color;
				refParticle.gameObject.transform.GetComponent<ParticleSystem>().Emit(20);
				//AudioSource.PlayClipAtPoint(explozijaSound,transform.position);
				Destroy(gameObject);//unisti ovaj objekat (objekat koji ima skriptu)
				//GameObject.Find("GameLogic").GetComponent<LevelLogic>().dodajScore();
			}
		}
	}
}
