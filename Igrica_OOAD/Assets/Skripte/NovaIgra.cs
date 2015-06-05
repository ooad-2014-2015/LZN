using UnityEngine;
using System.Collections;

public class NovaIgra : MonoBehaviour {

public void UcitajNovu(string nazivScene)
	{
		Kokica.brojac = 0;
		Application.LoadLevel (nazivScene);
	}

}
