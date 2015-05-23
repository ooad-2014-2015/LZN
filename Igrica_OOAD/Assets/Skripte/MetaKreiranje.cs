using UnityEngine;
using System.Collections;

public class MetaKreiranje : MonoBehaviour {
	//public Material[] materials;


	private float cooldown = -5f;//cooldown za kreiranje mete
	public float cooldownAmount = 2;
	public GameObject meta;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if(cooldown<0){
			createMeta();
			cooldown = cooldownAmount;
		}
		cooldown -= Time.deltaTime;

	}
	public void createMeta(){
		//Random meta na random x poziciji se kreira

			Vector3 createPosition = new Vector3(Random.Range(-4,4),Random.Range(3,6),0);
			GameObject metaObjekat = (GameObject) Instantiate(meta, createPosition, transform.rotation);
		
		Destroy (metaObjekat, 3);

		//metaObjekat.GetComponent<Meta>().refParticle = refParticle;//referenca na objekat za particle
		//int boja = (int)Random.Range(0,3);
		//metaObjekat.GetComponent<Meta>().boja = boja;
		//metaObjekat.GetComponent<Renderer>().material = materials[boja];
	}
}
