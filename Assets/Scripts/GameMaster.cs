using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public GameObject Fantasma1;
	public GameObject Fantasma2;
	public GameObject Fantasma3;
	public GameObject Fantasma4;
	public Material MFanstasma1;
	public Material MFanstasma2;
	public Material MFanstasma3;
	public Material MFanstasma4;
	public Material MFuga;
	public static bool Vivo = true;
	public static bool Fugir = false;
	public static int PosPlayer = 1;
	public static int PosPlayerPas = 1;
	public static int PosPlayerPro = 1;
	public static int Pontos = 0;
	public float TempoFuga = 10.0f;
	public float Timer = 0.0f;

    public static int direcaoDoPacMan = 0;

    public static Vector3[] deslocamentos = new Vector3[8];

    void Awake()
    {
        deslocamentos[0] = new Vector3( 0,  0, -7);
        deslocamentos[1] = new Vector3( 7,  0, -7);
        deslocamentos[2] = new Vector3( 7,  0,  0);
        deslocamentos[3] = new Vector3( 7,  0,  7);
        deslocamentos[4] = new Vector3( 0,  0,  7);
        deslocamentos[5] = new Vector3(-7,  0,  7);
        deslocamentos[6] = new Vector3(-7,  0,  0);
        deslocamentos[7] = new Vector3(-7,  0, -7);
    }

	void Update(){

		if (Fugir == true) {
			if(Timer==0.0f){
				Fantasma1.renderer.material = MFuga;
				Fantasma2.renderer.material = MFuga;
				Fantasma3.renderer.material = MFuga;
				Fantasma4.renderer.material = MFuga;
			}
			Timer += Time.deltaTime;
			if(Timer>=TempoFuga){
				Fugir = false;
			}
		} else {
			Timer = 0.0f;
			Fantasma1.renderer.material = MFanstasma1;
			Fantasma2.renderer.material = MFanstasma2;
			Fantasma3.renderer.material = MFanstasma3;
			Fantasma4.renderer.material = MFanstasma4;
		}

		if (Pontos >= 147) {
			Vivo = true;
			Fugir = false;
			Pontos = 0;
			Application.LoadLevel("Vitoria");
		}

		if (Vivo == false) {
			Vivo = true;
			Fugir = false;
			Pontos = 0;
			Application.LoadLevel("Derrota");
		}

		if (Input.GetKey("space")) {
			print("\nPos player = "+PosPlayer);
			print("\nPos player Pas = "+PosPlayerPas);
			print("\nPos player Pro= "+PosPlayerPro);
			print("\nPontos= "+Pontos);
		}

	}

}
