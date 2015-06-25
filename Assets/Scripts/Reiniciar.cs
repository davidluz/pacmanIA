using UnityEngine;
using System.Collections;

public class Reiniciar : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("r")) {
			GameMaster.Vivo = true;
			GameMaster.Fugir = false;
			GameMaster.Pontos = 0;
			Application.LoadLevel("teste");
		}
	}
}
