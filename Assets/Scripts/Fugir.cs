using UnityEngine;
using System.Collections;

public class Fugir : MonoBehaviour {

	public Transform Alvo;
	public NavMeshAgent AuxPosicaoNavMesh;
	public bool ativo = false;
	public float TempoLimite = 10.0f;
	public float Timer = 0.0f;
	public int destino = 0;
	public float TimerAdd = 0.0f;

	// Update is called once per frame
	void Update () {

		Timer += Time.deltaTime;
		TimerAdd += Time.deltaTime;

		if (Timer >= TempoLimite) {
			ativo = true;
		}
		if (ativo == true) {

			if(TimerAdd>=1){
				TimerAdd = 0.0f;
				int aux = destino;
				while(aux==destino){
					destino = Random.Range(0,8);
				}
			}
			AuxPosicaoNavMesh.destination = Alvo.position+GameMaster.deslocamentos[destino];
				
				
		}else{
				
		}//fim else ativo


	
	}

	/*
	void OnTriggerEnter(Collider collision){
		
		
		Tipo tipoDoElemento = collision.gameObject.GetComponent<Tipo> ();
		WayPoints waypoint = collision.gameObject.GetComponent<WayPoints> ();
		
		if (tipoDoElemento != null) {
			
			if (tipoDoElemento.tipo == Tipo.Elemento.WayPoints) {
				int aux = destino;
				while(aux==destino){
					destino = Random.Range(0,8);
				}

			}
		}
	}//trigger
	*/
}
