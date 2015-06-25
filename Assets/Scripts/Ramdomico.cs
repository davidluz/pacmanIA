using UnityEngine;
using System.Collections;

public class Ramdomico : MonoBehaviour {

	public Transform Alvo;
	public Transform[] WayPoints;
	public Transform AlvoAtualProx;
	public int NumeroAlvo = 1;
	public NavMeshAgent AuxPosicaoNavMesh;
	public bool ativo = false;
	public float TempoLimite = 10.0f;
	public float Timer = 0.0f;

	// Use this for initialization
	void Start () {
		AlvoAtualProx.position = Alvo.position;
	}
	
	// Update is called once per frame
	void Update () {


		Timer += Time.deltaTime;

		
		if (Timer >= TempoLimite) {
			ativo = true;
		}
		if (ativo == true) {

			AlvoAtualProx.position = WayPoints[NumeroAlvo].position;
			AuxPosicaoNavMesh.destination = AlvoAtualProx.position;
			
			
		}

	}//update


	void OnTriggerEnter(Collider collision){
		
		
		Tipo tipoDoElemento = collision.gameObject.GetComponent<Tipo> ();
		WayPoints waypoint = collision.gameObject.GetComponent<WayPoints> ();
		
		if (tipoDoElemento != null) {
			
			if (tipoDoElemento.tipo == Tipo.Elemento.WayPoints) {

				int aux = NumeroAlvo;
				while((aux==NumeroAlvo)||(NumeroAlvo==waypoint.Valor)){
					NumeroAlvo = Random.Range(1,63);
				}
				
			}
		}
	}//trigger


}
